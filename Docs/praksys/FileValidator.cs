#region Page Header

// <summary>
// File Name : FileValidator
// Description : File validator to validate incoming files 
// </summary>

#endregion Page Header

namespace Praksys.WebService.Administration.Filters
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>
    /// File validator to validate incoming files 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public sealed class FileValidator : ActionFilterAttribute
    {
        /// <summary>
        /// Validate extenion of incoming file against balck listed extension 
        /// </summary>
        /// <param name="actionContext">actionContext</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {              
                string vaildationErrorMessage = "Invalid filing, {0} not allowed.";
                string[] blackList = { "exe", "bat", "dll", "msi" };
                foreach (string file in HttpContext.Current.Request.Files)
                {
                    string fileName = HttpContext.Current.Request.Files[file].FileName.ToLower();                   
                    string extension = fileName.Split('.')[1];
                    if (blackList.Contains(extension))
                    {
                        var response = new HttpResponseMessage();
                        response.ReasonPhrase = string.Format(vaildationErrorMessage, extension);
                        response.Content = new StringContent(string.Format(vaildationErrorMessage, extension), System.Text.Encoding.UTF8, "text/plain");
                        response.StatusCode = HttpStatusCode.NotAcceptable;
                        actionContext.Response = response;
                        break;
                    }
                }

            }
        }
    }
}