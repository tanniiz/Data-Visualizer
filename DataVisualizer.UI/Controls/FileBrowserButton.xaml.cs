using System;
using System.Collections.Generic;
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
    /// Interaction logic for FileBrowserButton.xaml
    /// </summary>
    public partial class FileBrowserButton : UserControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty FileFilterProperty = DependencyProperty.Register("FileFilter", typeof(string), 
                                                            typeof(FileBrowserButton));

        public string FileFilter
        {
            get { return (string)GetValue(FileFilterProperty); }
            set { SetValue(FileFilterProperty, value); }
        }

        public static readonly DependencyProperty DefaultFileFilterProperty = DependencyProperty.Register("DefaultFileFilter", typeof(string),
                                                            typeof(FileBrowserButton));

        public string DefaultFileFilter
        {
            get { return (string)GetValue(DefaultFileFilterProperty); }
            set { SetValue(DefaultFileFilterProperty, value); }
        }
        #endregion

        public FileBrowserButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension +
            dlg.DefaultExt = this.DefaultFileFilter;
            dlg.Filter = this.FileFilter;


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                FileLocationTextBox.Text = filename;
            }
        }
    }
}
