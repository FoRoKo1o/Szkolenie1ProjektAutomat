using EntityDB.Context;
using System.Linq;
using System.Windows;

namespace ProjektAutomat.Admin
{
    public partial class AdminPanel : Window
    {
        private readonly Vend vend = new Vend();
        Model1 db = new Model1();
        public AdminPanel()
        {
            InitializeComponent();
            var Vends = db.Vends.ToList();
            var Products = db.Products.ToList();
            vend = Vends.ElementAt(0);
            Vend1List.ItemsSource = vend.Products;
        }
        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }
    }
}
