// <summary file = "FilterConfig.cs">
// Description : FilterConfig class
// </summary>

namespace Praksys.UI.Administration
{
    #region Namespaces
    using System.Web;
    using System.Web.Mvc;
    using Praksys.UI.Administration.Filters;
    #endregion

    /// <summary>
    /// Filter Config class
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register Global Filters
        /// </summary>
        /// <param name="filters">GlobalFilterCollection</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
           // filters.Add(new HandleErrorAttribute());
            filters.Add(new PraksysException());
            ////Disable cache for cshtml pages
            filters.Add(new OutputCacheAttribute
            {
                VaryByParam = "*",
                Duration = 0,
                NoStore = true,
                
            });
            
        }
    }
}
