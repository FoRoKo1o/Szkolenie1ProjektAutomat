using EntityDB.Context;
using System.Linq;
using System.Windows;

namespace ProjektAutomat.Admin
{
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Visibility = Visibility.Hidden;
            main.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Model1 db = new Model1();
            var Admins = db.Admins.ToList();
            bool flag = false;
            foreach(var admin in Admins)
            {
                if(Login.Text == admin.Username && password.Password == admin.Password)
                {
                    flag = true;
                    break;
                }
            }
            if(flag == true)
            {
                AdminPanel adminPanel = new AdminPanel();
                Close();
                adminPanel.Show();
            }
            else
            {
                message.Content = "Wrong username or password";
            }
        }
    }
}
