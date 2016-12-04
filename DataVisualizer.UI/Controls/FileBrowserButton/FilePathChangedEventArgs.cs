using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataVisualizer.UI.Controls
{
    public class FilePathChangedEventArgs : RoutedEventArgs
    {
        public string FilePath { get; set; }
    }
}
