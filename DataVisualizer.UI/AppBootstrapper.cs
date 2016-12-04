using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using DataVisualizer.UI.ApplicationShell;
using DataVisualizer.UI.Screens;

namespace DataVisualizer.UI
{
    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            base.Configure();

            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IApplicationShell, ApplicationShellViewModel>();
            container.PerRequest<IMainScreen, MainScreenViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            DisplayRootViewFor<IApplicationShell>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new InvalidOperationException("Could not locate any instances.");
        }
    }
}
