﻿using Prism.Logging;
using Prism.Mef.Modularity;
using Prism.Modularity;
using PrismHacking.Common;
using System.ComponentModel.Composition;

namespace Module1
{
    [ModuleExport(typeof(Module3))]
    public class Module3 : IModule
    {
        private const string ModuleName = "Module3";
        private ILoggerFacade _logger;
        private IModuleTracker _moduleTracker;

        [ImportingConstructor]
        public Module3(ILoggerFacade logger, IModuleTracker moduleTracker)
        {
            Guard.ArgumentNotNull(logger, nameof(logger));
            Guard.ArgumentNotNull(moduleTracker, nameof(moduleTracker));

            _logger = logger;
            _moduleTracker = moduleTracker;

            _moduleTracker.RecordModuleConstructed(ModuleName);
        }

        public void Initialize()
        {
            _logger.Log($"{ModuleName} demonstrates logging during Initialize().", Category.Info, Priority.Medium);
            _moduleTracker.RecordModuleInitialized(ModuleName);
        }
    }
}
