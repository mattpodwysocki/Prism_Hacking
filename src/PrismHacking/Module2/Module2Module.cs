using Module2.Views;
using Prism.Logging;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using PrismHacking.Common;
using System.ComponentModel.Composition;

namespace Module2
{
    [ModuleExport(typeof(Module2Module))]
    public class Module2Module : IModule
    {
        private const string ModuleName = "Module2";
        private ILoggerFacade _logger;
        private IModuleTracker _moduleTracker;
        private IRegionManager _regionManager;

        [ImportingConstructor]
        public Module2Module(ILoggerFacade logger, IModuleTracker moduleTracker, IRegionManager regionManager)
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

            _regionManager.RegisterViewWithRegion(RegionNames.Region2, typeof(ViewB));
        }
    }
}
