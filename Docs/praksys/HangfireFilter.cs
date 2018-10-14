#region Page Header

// <summary file="HangfireFilter.cs" company="Praksys.dk">
//      Description : Filter for dashbard authorization
// </summary>

#endregion Page Header

using System.Linq;
using System.Web;
using Hangfire.Dashboard;
using Praksys.Core.CommonUtility;
using Praksys.Model.Common;

namespace Praksys.WebService.Administration.Filters
{
    /// <summary>
    ///  Filter for dashbard authorization
    /// </summary>
    public class HangfireFilter : IDashboardAuthorizationFilter
    {
        /// <summary>
        /// Authorizes calls to Hangfire dashboard
        /// </summary>
        /// <param name="owinEnvironment">Owin context data</param>
        /// <returns>flag indicating whether call is authorized or not</returns>
        public bool Authorize(DashboardContext context)
        {
            if (string.IsNullOrEmpty(context.Request.Path))
            {
                if (HttpContext.Current.Request.Form != null && HttpContext.Current.Request.Form.HasKeys())
                {
                    string SAML = HttpContext.Current.Request.Form.GetValues(CommonConstants.SAMLHeaderKey).FirstOrDefault();
                    if (!string.IsNullOrEmpty(SAML) && UserProfileInfo.IsAuthorised(SAML))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}