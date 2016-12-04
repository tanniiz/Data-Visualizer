using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataVisualizer.UI.Framework;
using DataVisualizer.UI.Screens;

namespace DataVisualizer.UI.ApplicationShell
{
    public class ApplicationShellViewModel : ScreenControl<IScreen>,
        IApplicationShell
    {
        private MainScreenViewModel _mainScreen;
        public MainScreenViewModel MainScreen 
        { 
            get
            {
                return _mainScreen;
            }

            set
            {
                _mainScreen = value;
                NotifyOfPropertyChange(() => MainScreen);
            }
        }

        public ApplicationShellViewModel()
        {
            
        }

        protected override void Configuration()
        {
            base.Configuration();

            DisplayName = "Data Visualizer";
            MainScreen = new MainScreenViewModel();
        }
    }
}
