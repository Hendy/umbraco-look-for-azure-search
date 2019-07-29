using Our.Umbraco.Look.AzureSearch.Services;
using System.ComponentModel;
using Umbraco.Core;
using Umbraco.Web;

namespace Our.Umbraco.Look
{
    /// <summary>
    /// Umbraco start-up event to initialize Look for Azure Search
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)] // hide from api intellisense
    public class UmbracoStartUp : ApplicationEventHandler
    {
        /// <summary>
        /// Umbraco started
        /// </summary>
        /// <param name="umbracoApplication"></param>
        /// <param name="applicationContext"></param>
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            LookService.Initialize(new UmbracoHelper(UmbracoContext.Current));
        }
    }
}
