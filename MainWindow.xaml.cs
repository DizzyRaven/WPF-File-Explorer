using Project.BLL.Services;
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
using Project.BLL.DTO;
using System.Threading;

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserService service;
        UserDto currentUser;
        public MainWindow()
        {
            service = new UserService();
            Thread.Sleep(100);
            InitializeComponent();
        }
        public MainWindow(UserDto user)
            :this()
        {
            currentUser = user;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           
            UserQueryDto queryDto = new UserQueryDto()
            {
                Date = DateTime.Now,
                Path = path.Text,
                UserId = currentUser.Id
            };
            service.AddQuery(queryDto);
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
        private void AddQuery()
        {

        }
        private async void LogOut(object sender, RoutedEventArgs e)
        {

            //LoginManager.ClearDat();
            
                service.LogInOut(currentUser);

           // Application.Current.MainWindow = new LogInWindow();
            new LogInWindow().Show();
            this.Close();


        }
    }
}
