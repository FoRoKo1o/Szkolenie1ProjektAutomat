using ProjektAutomat.Admin;
using System.Windows;

namespace ProjektAutomat
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Vend1(object sender, RoutedEventArgs e)
        {
            Vend1 vend1 = new Vend1();
            this.Visibility = Visibility.Hidden;
            vend1.Show();
        }

        private void AdminLogin(object sender, RoutedEventArgs e)
        {
            AdminLogin adminLogin = new AdminLogin();
            Close();
            adminLogin.Show();
        }
    }
}
