using Prism.Modularity;
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
#pragma warning restore 0649 

        public Shell()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            DataContext = _moduleTracker;

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
    }
}
