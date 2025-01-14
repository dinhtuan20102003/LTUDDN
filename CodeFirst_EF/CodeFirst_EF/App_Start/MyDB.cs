using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using CodeFirst_EF.Models;
namespace CodeFirst_EF.App_Start
{
    //DropCreateDatabaseAlways
    public class MyDB : DropCreateDatabaseIfModelChanges<ShopDataContext>
    {
        protected override void Seed(ShopDataContext context)
        {
            context.Customers.Add(new Customer { CustomerId = 1, Name = "Tuan"});
            context.Customers.Add(new Customer { CustomerId = 2, Name = "Linh" });
            context.Customers.Add(new Customer { CustomerId = 3, Name = "Dung" });
            context.SaveChanges();
            context.Oders.Add(new Order { CustomerId =1, ProductName = "Banh My", Price = 20000, Quantity = 2});
            context.Oders.Add(new Order { CustomerId = 2, ProductName = "Cafe", Price = 10000, Quantity = 10 });
            context.Oders.Add(new Order { CustomerId = 3, ProductName = "Mi Tom", Price = 5000, Quantity = 100 });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}