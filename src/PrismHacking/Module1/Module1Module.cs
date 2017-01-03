using Module1.Views;
using Prism.Logging;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using PrismHacking.Common;
using System.ComponentModel.Composition;

namespace Module1
{
    [ModuleExport(typeof(Module1Module))]
    public class Module1Module : IModule
    {
        private const string ModuleName = "Module1";
        private readonly ILoggerFacade _logger;
        private readonly IModuleTracker _moduleTracker;
        private readonly IRegionManager _regionManager;

        [ImportingConstructor]
        public Module1Module(ILoggerFacade logger, IModuleTracker moduleTracker, IRegionManager regionManager)
        {
            Guard.ArgumentNotNull(logger, nameof(logger));
            Guard.ArgumentNotNull(moduleTracker, nameof(moduleTracker));
            Guard.ArgumentNotNull(regionManager, nameof(regionManager));

            _logger = logger;
            _moduleTracker = moduleTracker;
            _regionManager = regionManager;

            _moduleTracker.RecordModuleConstructed(ModuleName);
        }


        public void Initialize()
        {
            _logger.Log($"{ModuleName} demonstrates logging during Initialize().", Category.Info, Priority.Medium);
            _moduleTracker.RecordModuleInitialized(ModuleName);

            _regionManager.RegisterViewWithRegion(RegionNames.Region1, typeof(ViewA));
        }
    }
}
