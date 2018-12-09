using System;
using System.Collections.Generic;
using System.IO;
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

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ProgressBar.Value = 0;
            List<Models.Item> items = new List<Models.Item>();
            var itemProvider = new ItemProvider();
            try
            {
                items = await itemProvider.GetItemsAsync(path.Text);
                ProgressBar.Value = 100;
            }
            catch (Exception)
            {
                // TODO : add logic
            }
            DataContext = items;
        }
        private async void LogOut(object sender, RoutedEventArgs e)
        {
            LoginManager.ClearDat();
            LogInWindow logIn = new LogInWindow();
            logIn.Show();
            this.Close();
          
        }
    }
}
