// <summary file = "BindJson.cs">
// Description : Web Api Security Filter
// </summary>

namespace Praksys.WebService.Administration.Filters
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Protocols.WSTrust;
    using System.IdentityModel.Services;
    using System.IdentityModel.Tokens;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web;
    using System.Web.Http;
    using System.Web.Script.Serialization;
    using System.Xml;
    using Praksys.Model.User;
    using Praksys.Core.CommonUtility;
    using Praksys.Core.Exceptions;
    #endregion

    /// <summary>
    /// Web Api Security Filter
    /// </summary>
    public sealed class WebApiSecurityFilter : AuthorizeAttribute
    {
        /// <summary>
        /// Reader Quotas.
        /// </summary>
        ////private XmlDictionaryReaderQuotas _quotas;
        ////private WSFederationSerializer CreateSerializer(string resultXml)
        ////{
        ////    using (XmlDictionaryReader textReader = XmlDictionaryReader.CreateTextReader(Encoding.UTF8.GetBytes(resultXml), _quotas))
        ////        return new WSFederationSerializer(textReader);
        ////}

        /// <summary>
        /// overriding OnAuthorization method
        /// </summary>
        /// <param name="actionContext">HttpActionContext</param>
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
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
            ////actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}