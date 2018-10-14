// <summary file="CommonController.cs">
//     Description : Custom Attribute for Authorization
// </summary>

namespace Praksys.WebService.Administration.Filters
{
    using System.Net.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Text;
    using System.Web.Script.Serialization;
    using System.Web.Configuration;
    using Praksys.Model.User;
    using Praksys.Core.Exceptions;
    using Praksys.Core.CommonUtility;
    using Praksys.Model.Enums;

    /// <summary>
    /// Custom Attribute for Authorization
    /// </summary>
    public sealed class PraksysAuthorize : AuthorizeAttribute
    {
        /// <summary>
        /// Gets or sets RightsName
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public List<string> RightsName { get; set; }

        /// <summary>
        /// Gets or sets RightsName
        /// </summary>
        /// <value>
        /// String
        /// </value>
        public string MatchRigths { get; set; }

        /// <summary>
        /// Constructor for PraksysAuthorize
        /// </summary>
        /// <param name="Methodname">RightsName</param>
        /// <param name="match">Match operator</param>
        public PraksysAuthorize(string rightsName, string match)
        {
            this.RightsName = rightsName.Split(new char[] { ',' }).ToList();
            this.MatchRigths = match;

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PraksysAuthorize()
        {
        }

        /// <summary>
        /// Overridden Method IsAuthorized
        /// </summary>
        /// <param name="actionContext">actionContext</param>
        /// <returns>bool</returns>
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                int count = 0;
                bool IsAllowed = false;
                var sessionTokenHeader = "x-session-token";
                var thirdPartyTokenHeader = "x-thirdparty-Id";
                string UserToken = string.Empty;
                string[] Delimeter = new string[1] { ":~UserToken~:" };
                if (actionContext.Request.Headers.Contains(sessionTokenHeader))
                {
                    UserToken = actionContext.Request.Headers.FirstOrDefault(header => header.Key == sessionTokenHeader).Value.ToList()[0].ToString();
                    UserToken = Encryptor.Decrypt(UserToken);
                    if (UserToken.Contains(Delimeter[0]))
                    {
                        UserToken = UserToken.Split(Delimeter, StringSplitOptions.None)[1];
                    }
                    if (string.IsNullOrEmpty(UserToken))
                    {
                        IsAllowed = false;
                    }
                    else
                    {
                        if (this.RightsName == null)
                        {
                            IsAllowed = true;
                        }
                        else
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            UserDetail _user = serializer.Deserialize<UserDetail>(UserToken);
                            List<RettighedDetails> listObjRights = new List<RettighedDetails>();
                            foreach (var resp in _user.sansvarData)
                            {
                                if (resp.rettighedData != null && resp.rettighedData.Count > 0)
                                {
                                    listObjRights.AddRange(resp.rettighedData);
                                }
                            }
                            if (listObjRights.Count > 0)
                            {
                                if (this.MatchRigths == MatchRights.All)
                                {
                                    count = listObjRights.Where(x => this.RightsName.Contains(x.RettighedTekst)).Select(a => a.RettighedTekst).Distinct().Count();
                                    if (count == this.RightsName.Count)
                                    {
                                        IsAllowed = true;
                                    }

                                }
                                else if (this.MatchRigths == MatchRights.Any)
                                {
                                    count = listObjRights.Where(x => this.RightsName.Contains(x.RettighedTekst)).Count();
                                    if (count > 0)
                                    {
                                        IsAllowed = true;
                                    }
                                }

                            }
                            else
                            {
                                IsAllowed = false;
                            }
                        }
                    }
                }

                else if (actionContext.Request.Headers.Contains(thirdPartyTokenHeader))
                {
                    UserToken = actionContext.Request.Headers.FirstOrDefault(header => header.Key == thirdPartyTokenHeader).Value.ToList()[0].ToString();
                    if (!string.IsNullOrEmpty(UserToken) && (UserToken.Trim() == "ProviderSelfService" || UserToken.Trim() == "PraksysAuthorizedService"))
                    {
                        IsAllowed = true;
                    }
                    else
                    {
                        IsAllowed = false;
                    }
                }

                else
                {
                    IsAllowed = false;
                }

                if (IsAllowed)
                    this.InsertLoginID(actionContext);

                return IsAllowed;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }
        }

        /// <summary>
        /// overriding OnAuthorization method
        /// </summary>
        /// <param name="actionContext">HttpActionContext</param>
        private void InsertLoginID(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            try
            {
                HttpContext.Current.Items["UserData"] = null;
                HttpContext.Current.Items["LoggedID"] = null;
                //// x-session-token and x-thirdparty-Id are being used as hard coded. if we find these from web.config it is very lengthy code to implement. 
                var sessionTokenHeader = "x-session-token";
                var RSTRToken = string.Empty;
                string[] Delimeter = new string[1] { ":~UserToken~:" };
                if (actionContext.Request.Headers.Contains("x-thirdparty-Id"))
                {
                    HttpContext.Current.Items["LoggedID"] = "Third Party";
                    return;
                }
                if (actionContext.Request.Headers.Contains(sessionTokenHeader))
                {
                    RSTRToken = actionContext.Request.Headers.FirstOrDefault(header => header.Key == sessionTokenHeader).Value.ToList()[0].ToString();
                    RSTRToken = Encryptor.Decrypt(RSTRToken);
                    if (RSTRToken.Contains(Delimeter[0]))
                    {
                        HttpContext.Current.Items["LoggedID"] = UserProfileInfo.GetUserId(RSTRToken.Split(Delimeter, StringSplitOptions.None)[1]);
                        HttpContext.Current.Items["UserData"] = RSTRToken.Split(Delimeter, StringSplitOptions.None)[1];
                        RSTRToken = RSTRToken.Split(Delimeter, StringSplitOptions.None)[0];
                    }
                }

                return;
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(ex.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.BadRequest
                };
                throw new HttpResponseException(response);
            }

        }

    }

}