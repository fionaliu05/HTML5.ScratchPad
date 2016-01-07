namespace HTML5.ScratchPad.DDD.Infra.Data.Migrations
{
    using Domain.Entities;
    using EFContext;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            Collection<Product> defaultProducts = new Collection<Product>();
            defaultProducts.Add(new Product { ProductId = 1, Name = "XBoxOne", Value = 245.50M });
            defaultProducts.Add(new Product { ProductId = 2, Name = "Walking Dead T-Shirt", Value = 15.50M });
            defaultProducts.Add(new Product { ProductId = 2, Name = "Walking Dead Dead-Inside - T-Shirt", Value = 14.50M, CustomerId = 1 });

            List<Customer> defaultCustomers = new List<Customer>();

            //defaultCustomers.Add(new Customer { FirstName = "Rick", Surname = "Grimes", InceptionDate = DateTime.Now, Product = new Collection<Product> { defaultProducts[0] } });
            //defaultCustomers.Add(new Customer { FirstName = "Daryl", Surname = "Dixon", InceptionDate = DateTime.Now.AddDays(-7), Product = defaultProducts });
            //defaultCustomers.Add(new Customer { FirstName = "Glen", Surname = "Dunno", InceptionDate = DateTime.Now.AddMonths(-6) });

            defaultCustomers.Add(new Customer {
                CustomerId = 1, FirstName = "Rick", Surname = "Grimes",
                InceptionDate = DateTime.Now, Active = true,
                AddressId = 1, Address = new Address
                {
                    AddressId = 1,
                    AddressLine1 = "101 The Manse",
                    AddressLine2 = "Alexandria",
                    AddressLine4 = "ZombieLands",
                    Postcode = "ZLD 5LB"

                }
            });
            defaultCustomers.Add(new Customer { CustomerId = 2, FirstName = "Daryl", Surname = "Dixon", InceptionDate = DateTime.Now.AddDays(-7), Active = true });
            defaultCustomers.Add(new Customer { CustomerId = 3, FirstName = "Glen", Surname = "Dunno", InceptionDate = DateTime.Now.AddMonths(-6) });

            //http://hudosvibe.net/post/entityframework-one-to-one-with-foreign-keys
            // We need to create new Person without AddressId, save that to db to get its Id
            // and then create Address and fill both ends of relationship (PersonId and AddressId)
            // That's why Person.AddressId is nullable.


            foreach (Customer customer in defaultCustomers)
                context.Customers.AddOrUpdate(customer);

            foreach (Product product in defaultProducts)
                context.Products.AddOrUpdate(product);

        }
    }
}
