// <summary file="ModelValidator.cs">
//     Description : Validation filter to Validate models centrally
//     Author      : Ahmar Husain
//     Date        : 19 August 2016
// </summary>

namespace Praksys.WebService.Administration.Filters
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using System.Linq;
    using Praksys.Core.Logging;

    /// <summary>
    /// Action filter attribute to validate models from one place
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
    public sealed class ModelValidator : ActionFilterAttribute
    {
        /// <summary>
        /// Function that automatically runs before the execution of action and validates the incoming model (DTO)
        /// </summary>
        /// <param name="actionContext">HttpActionContext</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var response = new HttpResponseMessage();
                string vaildationErrorMessage = string.Empty;
                var Exception = actionContext.ModelState.SelectMany(item => item.Value.Errors.Where(error => error.Exception != null)).FirstOrDefault();
                if (!object.ReferenceEquals(Exception, null))
                {
                    vaildationErrorMessage = actionContext.ModelState.SelectMany(item => item.Value.Errors.Where(error => error.Exception != null)
                        .Select(error => new Exception("Key :" + item.Key + " Message :" + error.Exception.Message))).FirstOrDefault().ToString();
                }
                vaildationErrorMessage = string.Concat(vaildationErrorMessage, string.Join(",", actionContext.ModelState.Keys.SelectMany(k => actionContext.ModelState[k].Errors).Select(m => m.ErrorMessage).ToArray()));
                response.ReasonPhrase = vaildationErrorMessage;
                response.Content = new StringContent(vaildationErrorMessage, System.Text.Encoding.UTF8, "text/plain");
                LogWrapper.getInstance().Fatal("Model Validation Failed ,Request Object :: " + actionContext.Request.ToString() + " , Detail Message::" + vaildationErrorMessage);
                response.StatusCode = HttpStatusCode.NotAcceptable;
                actionContext.Response = response;
            }
        }
    }
}
