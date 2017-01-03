﻿using System.Windows;

namespace PrismShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bootstrapper = new PrismHackingBootstrapper();
            bootstrapper.Run();
        }
    }
}
