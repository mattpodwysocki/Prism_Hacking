using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Logging;
using Moq;
using Prism.Regions;
using PrismHacking.Common;
using Module1.Views;

namespace Module1.Tests
{
    [TestClass]
    public class Module1ModuleFixture
    {
        private const string ModuleName = "Module1";
        private const string RegionName = "Region1";

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Null_Logger_Should_Throw()
        {
            var logger = default(ILoggerFacade);
            var moduleTracker = new Mock<IModuleTracker>();
            var regionManager = new Mock<IRegionManager>();

            moduleTracker.SetupAllProperties();
            regionManager.SetupAllProperties();

            var module = new Module1Module(logger, moduleTracker.Object, regionManager.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Null_ModuleTracker_Should_Throw()
        {
            var logger = new Mock<ILoggerFacade>();
            var moduleTracker = default(IModuleTracker);
            var regionManager = new Mock<IRegionManager>();

            logger.SetupAllProperties();
            regionManager.SetupAllProperties();

            var module = new Module1Module(logger.Object, moduleTracker, regionManager.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_Null_RegionManager_Should_Throw()
        {
            var logger = new Mock<ILoggerFacade>();
            var moduleTracker = new Mock<IModuleTracker>();
            var regionManager = default(IRegionManager);

            logger.SetupAllProperties();
            moduleTracker.SetupAllProperties();

            var module = new Module1Module(logger.Object, moduleTracker.Object, regionManager);
        }

        [TestMethod]
        public void Ctor_ModuleTracker_Records_Construction()
        {
            var logger = new Mock<ILoggerFacade>();
            var moduleTracker = new Mock<IModuleTracker>();
            var regionManager = new Mock<IRegionManager>();

            logger.SetupAllProperties();
            moduleTracker.SetupAllProperties();
            regionManager.SetupAllProperties();

            var module = new Module1Module(logger.Object, moduleTracker.Object, regionManager.Object);

            moduleTracker.Verify(x => x.RecordModuleConstructed(ModuleName), Times.Once());
        }

        [TestMethod]
        public void Initialize_Logger_Should_Log()
        {
            var logger = new Mock<ILoggerFacade>();
            var moduleTracker = new Mock<IModuleTracker>();
            var regionManager = new Mock<IRegionManager>();

            logger.SetupAllProperties();
            moduleTracker.SetupAllProperties();
            regionManager.SetupAllProperties();

            var module = new Module1Module(logger.Object, moduleTracker.Object, regionManager.Object);

            module.Initialize();

            logger.Verify(x => x.Log($"{ModuleName} demonstrates logging during Initialize().", Category.Info, Priority.Medium), Times.Once());
        }

        [TestMethod]
        public void Initialize_ModuleTracker_Should_Record_Initialized()
        {
            var logger = new Mock<ILoggerFacade>();
            var moduleTracker = new Mock<IModuleTracker>();
            var regionManager = new Mock<IRegionManager>();

            logger.SetupAllProperties();
            moduleTracker.SetupAllProperties();
            regionManager.SetupAllProperties();

            var module = new Module1Module(logger.Object, moduleTracker.Object, regionManager.Object);

            module.Initialize();

            moduleTracker.Verify(x => x.RecordModuleInitialized(ModuleName), Times.Once());
        }

        public void Initialize_RegionManager_Should_Register_View()
        {
            var logger = new Mock<ILoggerFacade>();
            var moduleTracker = new Mock<IModuleTracker>();
            var regionManager = new Mock<IRegionManager>();

            logger.SetupAllProperties();
            moduleTracker.SetupAllProperties();
            regionManager.SetupAllProperties();

            var module = new Module1Module(logger.Object, moduleTracker.Object, regionManager.Object);

            module.Initialize();

            regionManager.Verify(x => x.RegisterViewWithRegion(RegionName, typeof(ViewA)), Times.Once());
        }
    }
}
