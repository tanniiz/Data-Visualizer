using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DataVisualizer.UI.Controls;
using DataVisualizer.UI.Framework;
using DataVisualizer.UI.Utils;

namespace DataVisualizer.UI.Screens
{
    public class MainScreenViewModel : ScreenControl<IScreen>, 
        IMainScreen
    {
        private List<string> _dataColumns;
        public List<string> DataColumns
        {
            get
            {
                return _dataColumns;
            }

            set
            {
                _dataColumns = value;
                NotifyOfPropertyChange(() => DataColumns);
            }
        }

        private List<List<string>> _dataRows;
        public List<List<string>> DataRows
        {
            get
            {
                return _dataRows;
            }

            set
            {
                _dataRows = value;
                NotifyOfPropertyChange(() => DataRows);
            }
        }

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
            if (!string.IsNullOrWhiteSpace(this.FilePath)) 
            {
                var data = CSVUtils.ReadCSVFile(this.FilePath);
                DataColumns = data[0];
                DataRows = data.GetRange(1, data.Count - 2);
            }
        }
    }
}
