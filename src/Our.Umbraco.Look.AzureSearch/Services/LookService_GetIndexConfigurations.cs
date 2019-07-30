using Our.Umbraco.Look.AzureSearch.Models;
using System.Collections.Generic;

namespace Our.Umbraco.Look.AzureSearch.Services
{
    internal partial class LookService
    {
        internal static Dictionary<string, IndexConfiguration> GetIndexConfigurations()
        {
            return LookService.Instance._indexConfigurations;
        }
    }
}
