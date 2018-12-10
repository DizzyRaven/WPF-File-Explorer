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
using System.Windows.Shapes;
using Project.BLL.Services;
using Project.BLL.Interfaces;
using Project.BLL.DTO;

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        UserService service;
        UserDto currnetUser;
        public LogInWindow()
        {
            service = new UserService();
            InitializeComponent();

            var users = service.GetUsers();
            var user = users.FirstOrDefault(u => u.IsLoggedIn == true);
            if (user != null)
            {
                currnetUser = user;
                Login();
                service.LogInUser(user);
            }
            //try
            //{
            //    var user = LoginManager.DeserializeUser();
            //    if (user != null)
            //        Login();
            //}
            //catch (Exception)
            //{

            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = service.GetUsers().FirstOrDefault(u => u.UserName == username.Text);
            if (user != null)
            {
                if (user.Password == password.Password)
                {
                    currnetUser = user;
                    Login();
                    service.LogInUser(user);
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }

            }
            else
            {
                MessageBox.Show("Invalid login");
            }
        }
        private void Login()
        {
            MainWindow main = new MainWindow(currnetUser);
            main.Show();
            this.Close();
        }
    }
}
