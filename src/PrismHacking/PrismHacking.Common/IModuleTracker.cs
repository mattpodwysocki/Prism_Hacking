namespace PrismHacking.Common
{
    public interface IModuleTracker
    {
        /// <summary>
        /// Records the module is loading.
        /// </summary>
        /// <param name="moduleName">The module name.</param>
        /// <param name="bytesReceived">The number of bytes downloaded.</param>
        void RecordModuleDownloading(string moduleName, long bytesReceived, long totalBytesToReceive);

        /// <summary>
        /// Records the module has been loaded.
        /// </summary>
        ///<param name="moduleName">The module name.</param>
        void RecordModuleLoaded(string moduleName);

        /// <summary>
        /// Records the module has been constructed.
        /// </summary>
        /// <param name="moduleName">The module name.</param>
        void RecordModuleConstructed(string moduleName);

        /// <summary>
        /// Records the module has been initialized.
        /// </summary>
        /// <param name="moduleName">The module name.</param>
        void RecordModuleInitialized(string moduleName);
    }
}