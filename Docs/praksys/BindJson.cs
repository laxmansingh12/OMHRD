// <summary file = "BindJson.cs">
// Description : Bind Json
// </summary>

namespace Praksys.WebService.Administration.Filters
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Script.Serialization;
    #endregion

    /// <summary>
    /// Bind Json
    /// </summary>
    public sealed class BindJson : System.Web.Http.Filters.ActionFilterAttribute
    {
        /// <summary>
        /// Type field
        /// </summary>
        private Type _type;

        /// <summary>
        /// string field
        /// </summary>
        private string _queryStringKey;

        /// <summary>
        /// Bind Json
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="queryStringKey">string</param>
        public BindJson(Type type, string queryStringKey)
        {
            this._type = type;
            this._queryStringKey = queryStringKey;
        }

        /// <summary>
        /// overriding base class method
        /// </summary>
        /// <param name="actionContext">HttpActionContext</param>
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            ////read api key from query string
            string querystring = actionContext.Request.RequestUri.Query;
            var json = HttpUtility.ParseQueryString(querystring).Get(this._queryStringKey);

            var serializer = new JavaScriptSerializer();
            actionContext.ActionArguments[this._queryStringKey] = serializer.Deserialize(json, this._type);
        }
    }
}