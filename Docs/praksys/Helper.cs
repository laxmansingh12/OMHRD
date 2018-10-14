#region Page Header
// <summary file="CookieHelper.cs" company="Praksys.dk">
//      Description :Class used for Cookie Management
// </summary>
#endregion

namespace Praksys.UI.Administration.App_Start
{
    using System;
    using System.Web;
    using Praksys.UI.Administration.Models;
    using Newtonsoft.Json;

    /// <summary>
    /// Class to manage Cookie
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// Get User Seesion
        /// </summary>       
        /// <returns>SessionContext</returns>
        public SessionContext GetSession()
        {
            string serializedToken = HttpContext.Current.Request.Form["sessionToken"].ToString();
            string SessionToken = Encryptor.Decrypt(serializedToken);
            return JsonConvert.DeserializeObject<SessionContext>(SessionToken);
        }

        /// <summary>
        /// Get User From Header
        /// </summary>
        /// <returns>User</returns>
        public User GetHeaderSession()
        {
            if (HttpContext.Current.Request.Headers != null && HttpContext.Current.Request.Headers["x-session-token"] != null)
            {
                string[] Delimeter = new string[1] { ":~UserToken~:" };
                string token = Encryptor.Decrypt(HttpContext.Current.Request.Headers["x-session-token"].ToString());
                string encrypted_token = token.Split(Delimeter, StringSplitOptions.None)[1];
                return JsonConvert.DeserializeObject<User>(encrypted_token);
            }
            return null;
        }

    }
}