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

namespace CSharpProject
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
            try
            {
                var user = LoginManager.DeserializeUser();
                if (user != null)
                    Login();
            }
            catch (Exception)
            {

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (LoginManager.ValidateUser(username.Text, password.Password))
            {
                Login();
            }
            else
            {
                MessageBox.Show("Invalid login or password");
            }
        }
        private void Login()
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
