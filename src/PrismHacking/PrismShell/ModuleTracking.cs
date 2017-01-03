using PrismHacking.Common;
using System.ComponentModel.Composition;
using Prism.Logging;

namespace PrismShell
{
    [Export(typeof(IModuleTracker))]
    public class ModuleTracker : IModuleTracker
    {
#pragma warning disable 649  // MEF will import
        [Import]
        private ILoggerFacade _logger;
#pragma warning restore 649

        public void RecordModuleConstructed(string moduleName)
        {
            _logger.Log($"'{moduleName}' module constructed.", Category.Debug, Priority.Low);
        }

        public void RecordModuleDownloading(string moduleName, long bytesReceived, long totalBytesToReceive)
        {
            _logger.Log($"'{moduleName}' module is loading {bytesReceived}/{totalBytesToReceive} bytes.", Category.Debug, Priority.Low);
        }

        public void RecordModuleInitialized(string moduleName)
        {
            _logger.Log($"'{moduleName}' module initialized", Category.Debug, Priority.Low);
        }

        public void RecordModuleLoaded(string moduleName)
        {
            _logger.Log($"'{moduleName}' module loaded.", Category.Debug, Priority.Low);
        }
    }
}
