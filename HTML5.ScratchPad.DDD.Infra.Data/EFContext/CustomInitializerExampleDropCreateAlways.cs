using HTML5.ScratchPad.DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace HTML5.ScratchPad.DDD.Infra.Data.EFContext
{
    public class CustomInitializerExampleDropCreateAlways : DropCreateDatabaseAlways<ProjectModelContext>
    {
        protected override void Seed(ProjectModelContext context)
        {
            //IList<Product> defaultProducts = new List<Product>();
            //defaultProducts.Add(new Product { Name = "XBoxOne", Value = 245.50M });
            //defaultProducts.Add(new Product { Name = "Walking Dead T-Shirt", Value = 15.50M });

            //IList<Customer> defaultCustomers = new List<Customer>();

            //defaultCustomers.Add(new Customer { FirstName = "Rick", Surname = "Grimes", InceptionDate = DateTime.Now, Product = new Collection<Product> { defaultProducts[0] } });
            //defaultCustomers.Add(new Customer { FirstName = "Daryl", Surname = "Dixon", InceptionDate = DateTime.Now.AddDays(-7), Product = (Collection<Product>) defaultProducts });
            //defaultCustomers.Add(new Customer { FirstName = "Glen", Surname = "Dunno", InceptionDate = DateTime.Now.AddMonths(-6) });

            //foreach (Product product in defaultProducts)
            //    context.Products.Add(product);

            //foreach (Customer customer in defaultCustomers)
            //    context.Customers.Add(customer);

            base.Seed(context);
        }
    }
}
