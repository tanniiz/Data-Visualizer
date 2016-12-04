using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataVisualizer.UI.Controls;

namespace DataVisualizer.UI.Screens
{
    interface IMainScreen
    {
        string filter
        {
            get;
        }

        void FilePathChanged(FilePathChangedEventArgs args);

        void ProceedData();
    }
}
