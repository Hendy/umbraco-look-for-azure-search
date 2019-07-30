using Microsoft.VisualStudio.TestTools.UnitTesting;
using Our.Umbraco.Look.AzureSearch.Services;

namespace Our.Umbraco.Look.AzureSearch.Tests
{
    [TestClass]
    public static class Initialize
    {
        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext testContext)
        {
            // TODO: always start with an empty index
            //TestHelper.DeleteIndex();

            // Wire up the location indexers
            LookService.Initialize(null);
        }
    }
}
