using System;
//using SBMSservices.Services;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Owin.Security.OAuth;
using SBMS.BAL;

namespace OMHRD.API
{
    public class OAuthProvider : OAuthAuthorizationServerProvider
    {
        #region[GrantResourceOwnerCredentials]
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" }); -- responsible for pre-flight issue
            return Task.Factory.StartNew(() =>
            {
                var adminBL = new AdminBL();
                var userName = context.UserName;
                var password = context.Password;
                var user = adminBL.LoginAdmin(userName, password); // our created one
                //var user = userService.ValidateUser(userName, password);
                if (user != null)
                {
                    if (user.Active)
                    {
                        string StateId = "";
                        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("Username", user.Username));
                        identity.AddClaim(new Claim("ID", Convert.ToString(user.Id)));
                        identity.AddClaim(new Claim("Name", user.Name));
                        identity.AddClaim(new Claim(ClaimTypes.Role, user.IsSuperAdmin == true ? "Admin" : "User"));
                        identity.AddClaim(new Claim("LastLogin", Convert.ToString(user.LastLogin)));
                        var companyDT = adminBL.GetCompanyProfile();
                        if (companyDT.Rows.Count > 0)
                        {
                            StateId = companyDT.Rows[0]["StateId"].ToString();
                        }
                        var additionalData = new AuthenticationProperties(new Dictionary<string, string>{
                        { "Username", user.Username },
                        { "ID", Convert.ToString(user.Id) },
                        { "Name", user.Name },
                        { "StateId", StateId },
                        { "Role", user.IsSuperAdmin==true?"Admin":"User" },
                         { "LastLogin", Convert.ToString(user.LastLogin) }
                    });
                        var token = new AuthenticationTicket(identity, additionalData);
                        context.Validated(token);
                    }
                    else
                    {
                        context.SetError("invalid_grant", "Your account is inactive. Contact your system administrator to activate it.");
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Username and Password are incorrect.");
                }
            });
        }
        #endregion

        #region[ValidateClientAuthentication]
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
                context.Validated();

            return Task.FromResult<object>(null);
        }
        #endregion

        #region[TokenEndpoint]
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
        #endregion

      
    }
}
