using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataVisualizer.UI.Controls;
using DataVisualizer.UI.Framework;

namespace DataVisualizer.UI.Screens
{
    public class MainScreenViewModel : ScreenControl<IScreen>, 
        IMainScreen
    {
        public string FilePath { get; set; }
        public string filter
        {
            get
            {
                return "CSV Files (*.csv)|*.csv";
            }
        }
    
        public void FilePathChanged(FilePathChangedEventArgs args)
        {
            this.FilePath = args.FilePath;
        }

        public void ProceedData()
        {

        }
    }
}
