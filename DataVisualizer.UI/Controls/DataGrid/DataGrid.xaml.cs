using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataVisualizer.UI.Controls
{
    /// <summary>
    /// Interaction logic for DataGrid.xaml
    /// </summary>
    public partial class DataGrid : UserControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty DataColumnsProperty = DependencyProperty.Register("DataColumns", typeof(List<string>),
                                                        typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnColumnsChanged)));

        public List<string> DataColumns
        {
            get { return (List<string>)GetValue(DataColumnsProperty); }
            set { SetValue(DataColumnsProperty, value); }
        }

        public static readonly DependencyProperty DataRowsProperty = DependencyProperty.Register("DataRows", typeof(List<List<string>>),
                                                        typeof(DataGrid), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnRowsChanged)));

        public List<List<string>> DataRows
        {
            get { return (List<List<string>>)GetValue(DataRowsProperty); }
            set { SetValue(DataRowsProperty, value); }
        }
        #endregion

        public DataTable DataTable { get; set; }

        public DataGrid()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataTable = new DataTable();
        }

        private static void OnColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) 
        {
            var control = sender as DataGrid;
            control.UpdateColumn((List<string>)e.NewValue);
        }

        private void UpdateColumn(List<string> columns)
        {
            if (DataTable == null) 
            {
                DataTable = new DataTable();
            }

            if (columns != null) 
            {
                DataTable.Columns.Clear();

                columns.ForEach(x => DataTable.Columns.Add(x));
            }

            DisplayTable.ItemsSource = DataTable.DefaultView;
        }

        private static void OnRowsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var control = sender as DataGrid;
            control.UpdateRows((List<List<string>>)e.NewValue);
        }

        private void UpdateRows(List<List<string>> rows)
        {
            if (DataTable == null)
            {
                DataTable = new DataTable();
            }

            if (rows != null)
            {
                DataTable.Rows.Clear();

                DataRows.ForEach(x => DataTable.Rows.Add(x.ToArray<object>()));
            }

            DisplayTable.ItemsSource = DataTable.DefaultView;
        }
    }
}
