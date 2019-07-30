using Our.Umbraco.Look.AzureSearch.Models;
using System;
using System.Collections.Generic;
using Umbraco.Web;

namespace Our.Umbraco.Look.AzureSearch.Services
{
    /// <summary>
    /// Singleton class
    /// </summary>
    internal partial class LookService
    {
        /// <summary>
        /// Flag to indicate whether the look service has been initialized
        /// </summary>
        private bool _initialized = false;

        /// <summary>
        /// Locking obj to prevent multiple initialization
        /// </summary>
        private object _initializationLock = new object();

        /// <summary>
        /// Supplied by the initialization event (for re-use by the LookMatch)
        /// </summary>
        private UmbracoHelper _umbracoHelper;

        /// <summary>
        /// Collection of index configuration models, keyed by the azure search index name
        /// </summary>
        private Dictionary<string, IndexConfiguration> _indexConfigurations = new Dictionary<string, IndexConfiguration>();

        /// <summary>
        /// Access the singleton instance of this search service
        /// </summary>
        private static LookService Instance => _lazy.Value;

        /// <summary>
        /// Singleton instance
        /// </summary>
        private static readonly Lazy<LookService> _lazy = new Lazy<LookService>(() => new LookService());

        /// <summary>
        /// Singleton constructor
        /// </summary>
        private LookService()
        {
        }
    }
}
