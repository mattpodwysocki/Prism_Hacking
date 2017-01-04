using Prism.Modularity;
using Prism.Regions;
using PrismHacking.Common;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows;

namespace PrismShell
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window, IPartImportsSatisfiedNotification
    {
#pragma warning disable 0649 // Imported by MEF
        [Import(AllowRecomposition = false)]
        private IModuleTracker _moduleTracker;

        [Import(AllowRecomposition = false)]
        private IModuleManager _moduleManager;

        [Import(AllowRecomposition = false)]
        private PrismHackingLogger _logger;

        [Import(AllowRecomposition = false)]
        private IRegionManager _regionManager;
#pragma warning restore 0649 

        public Shell()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            _logger.Callback = (message, category, priority) => Debug.WriteLine($"[{category}][{priority}] {message}");
            _logger.ReplayLogs();

            Observable.FromEventPattern<LoadModuleCompletedEventArgs>(
                    h => _moduleManager.LoadModuleCompleted += h,
                    h => _moduleManager.LoadModuleCompleted -= h)
                .Subscribe(OnLoadModuleCompleted);
            Observable.FromEventPattern<ModuleDownloadProgressChangedEventArgs>(
                    h => _moduleManager.ModuleDownloadProgressChanged += h,
                    h => _moduleManager.ModuleDownloadProgressChanged -= h)
                .Subscribe(OnModuleDownloadProgressChanged);
        }

        private void OnLoadModuleCompleted(EventPattern<LoadModuleCompletedEventArgs> p)
        {
            _moduleTracker.RecordModuleLoaded(p.EventArgs.ModuleInfo.ModuleName);
        }

        private void OnModuleDownloadProgressChanged(EventPattern<ModuleDownloadProgressChangedEventArgs> p)
        {
            _moduleTracker.RecordModuleDownloading(p.EventArgs.ModuleInfo.ModuleName, p.EventArgs.BytesReceived, p.EventArgs.TotalBytesToReceive);
        }

        private void ViewARemove(object sender, RoutedEventArgs e)
        {
            _regionManager.Regions["Region1"].RemoveAllViews();
        }

        private void ViewBRemove(object sender, RoutedEventArgs e)
        {
            _regionManager.Regions["Region2"].RemoveAllViews();
        }

        private void ViewCRemove(object sender, RoutedEventArgs e)
        {
            _regionManager.Regions["Region3"].RemoveAllViews();
        }
    }
}
