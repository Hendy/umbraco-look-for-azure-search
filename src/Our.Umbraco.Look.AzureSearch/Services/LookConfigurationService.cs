using Our.Umbraco.Look.AzureSearch.Models;
using System.Collections.Generic;

namespace Our.Umbraco.Look.AzureSearch.Services
{
    /// <summary>
    /// Public API to configure how look operates
    /// </summary>
    public static class LookConfigurationService
    {
        /// <summary>
        /// Each item in dictionary represents one azure search index
        /// </summary>
        public static Dictionary<string, IndexConfiguration> IndexConfiguration => LookService.GetIndexConfigurations();

        // TODO: default indexers

        // TODO: before and after indexing
    }
}
