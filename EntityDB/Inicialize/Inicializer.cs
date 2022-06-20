using EntityDB.Context;
using EntityDB.Model;
using ProjektAutomat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityDB.Inicialize
{
    public class Inicializer
    {
        public void Data()
        {
            Model1 db = new Model1();

            db.Vends.ToList();
            var Vends = new List<Vend>
            {
                new Vend{ CustomerBalance = 0, VendBalance = 0, Products = db.Products.ToList()},
            };
            Vends.ForEach(v => db.Vends.Add(v));

            var Products = new List<Product>
            {
                new Product{Name = "Cola", Cost = 5, Quantity =10, VendID = 1},
                new Product{Name = "Sprite", Cost = 5, Quantity =10, VendID = 1},
                new Product{Name = "Mars", Cost = 2.1f, Quantity =20, VendID = 1},
                new Product{Name = "Snickers", Cost = 2.5f, Quantity =20, VendID = 1},
                new Product{Name = "Pepsi", Cost = 3.7f, Quantity =10, VendID = 1},
                new Product{Name = "chips", Cost = 6, Quantity =15, VendID = 1},

            };
            Products.ForEach(p => db.Products.Add(p));

            db.Admins.ToList();
            var Admins = new List<Admin>
            {
                new Admin{ Username = "admin", Password = "admin"},
            };
            Admins.ForEach(a => db.Admins.Add(a));

            db.SaveChanges();
        }
    }
}
