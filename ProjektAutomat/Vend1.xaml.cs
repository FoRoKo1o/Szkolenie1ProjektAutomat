using EntityDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace ProjektAutomat
{
    public partial class Vend1 : Window
    {
        Model1 db = new Model1();
        private readonly Vend vend = new Vend();
        public Vend1()
        {
            InitializeComponent();
            var Vends = db.Vends.ToList();
            var Products = db.Products.ToList();
            vend = Vends.ElementAt(0);
            UpdateProducts();
        }
        void UpdateProducts()
        {
            Product1.Content = vend.Products.ElementAt(0).Name;
            Product2.Content = vend.Products.ElementAt(1).Name;
            Product3.Content = vend.Products.ElementAt(2).Name;
            Product4.Content = vend.Products.ElementAt(3).Name;
            Product5.Content = vend.Products.ElementAt(4).Name;
            Product6.Content = vend.Products.ElementAt(5).Name;
            Product1_price.Content = "Price: " + vend.Products.ElementAt(0).Cost.ToString();
            Product2_price.Content = "Price: " + vend.Products.ElementAt(1).Cost.ToString();
            Product3_price.Content = "Price: " + vend.Products.ElementAt(2).Cost.ToString();
            Product4_price.Content = "Price: " + vend.Products.ElementAt(3).Cost.ToString();
            Product5_price.Content = "Price: " + vend.Products.ElementAt(4).Cost.ToString();
            Product6_price.Content = "Price: " + vend.Products.ElementAt(5).Cost.ToString();
            Product1_quantity.Content = "Quantity: " + vend.Products.ElementAt(0).Quantity.ToString();
            Product2_quantity.Content = "Quantity: " + vend.Products.ElementAt(1).Quantity.ToString();
            Product3_quantity.Content = "Quantity: " + vend.Products.ElementAt(2).Quantity.ToString();
            Product4_quantity.Content = "Quantity: " + vend.Products.ElementAt(3).Quantity.ToString();
            Product5_quantity.Content = "Quantity: " + vend.Products.ElementAt(4).Quantity.ToString();
            Product6_quantity.Content = "Quantity: " + vend.Products.ElementAt(5).Quantity.ToString();
        }
        private void Add5_Click(object sender, RoutedEventArgs e)
        {
            vend.CustomerBalance += 5;
            log.Text += "\nAdded 5, new balance: " + vend.CustomerBalance;
            UpdateBalance();
        }
        private void Add10_Click(object sender, RoutedEventArgs e)
        {
            vend.CustomerBalance += 10;
            log.Text += "\nAdded 10, new balance: " + vend.CustomerBalance;
            UpdateBalance();
        }
        private void Add20_Click(object sender, RoutedEventArgs e)
        {
            vend.CustomerBalance += 20;
            log.Text += "\nAdded 20, new balance: " + vend.CustomerBalance;
            UpdateBalance();
        }
        private void UpdateBalance()
        {
            var balance = decimal.Parse(vend.CustomerBalance.ToString());
            Balance.Content = decimal.Round(balance, 2, MidpointRounding.AwayFromZero);
        }
        private void BuyProduct(int product)
        {
            if (vend.CustomerBalance < vend.Products.ElementAt(product).Cost)
            {
                Balance.Content = "OUT OF FUNDS";
                log.Text += "\nOut of funds, remaining balance: " + vend.CustomerBalance;
            }
            else if (vend.Products.ElementAt(product).Quantity == 0)
            {
                Balance.Content = "OUT OF ORDER";
                log.Text += "\nOut of product " + product;
            }
            else
            {
                vend.CustomerBalance -= vend.Products.ElementAt(product).Cost;
                vend.VendBalance += vend.Products.ElementAt(product).Cost;
                vend.Products.ElementAt(product).Quantity -= 1;
                log.Text += "\nBought product " + product + " new balance: " + vend.CustomerBalance + ", Rremaining quantity " + vend.Products.ElementAt(product).Quantity;
                UpdateProducts();
                UpdateBalance();
            }
        }
        private void Product1_Buy(object sender, RoutedEventArgs e) => BuyProduct(0);
        private void Product2_Buy(object sender, RoutedEventArgs e) => BuyProduct(1);
        private void Product3_Buy(object sender, RoutedEventArgs e) => BuyProduct(2);
        private void Product4_Buy(object sender, RoutedEventArgs e) => BuyProduct(3);
        private void Product5_Buy(object sender, RoutedEventArgs e) => BuyProduct(4);
        private void Product6_Buy(object sender, RoutedEventArgs e) => BuyProduct(5);
        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            Close();
            main.Show();
        }
    }
}
