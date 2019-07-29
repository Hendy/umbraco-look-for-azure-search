using Umbraco.Core.Logging;
using Umbraco.Web;

namespace Our.Umbraco.Look.AzureSearch.Services
{
    internal partial class LookService
    {
        /// <summary>
        /// Ensure the service state has been initialized (first call constructs - handles locking)
        /// </summary>
        /// <param name="umbracoHelper"></param>
        internal static void Initialize(UmbracoHelper umbracoHelper)
        {
            if (!LookService.Instance._initialized)
            {
                lock (LookService.Instance._initializationLock)
                {
                    if (!LookService.Instance._initialized)
                    {
                        LogHelper.Info(typeof(LookService), "Initializing...");

                        LookService.Instance._umbracoHelper = umbracoHelper;
                    }
                }
            }
        }
    }
}
