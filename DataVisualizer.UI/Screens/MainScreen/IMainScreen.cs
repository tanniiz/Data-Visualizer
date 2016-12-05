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

        List<string> DataColumns
        {
            get;
            set;
        }

        List<List<string>> DataRows
        {
            get;
            set;
        }

        void FilePathChanged(FilePathChangedEventArgs args);

        void ProceedData();
    }
}
