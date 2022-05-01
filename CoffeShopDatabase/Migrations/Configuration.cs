﻿namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Utilities;
    using static System.Net.Mime.MediaTypeNames;

    internal sealed class Configuration : DbMigrationsConfiguration<CoffeShopDatabase.CoffeShopDbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CoffeShopDatabase.CoffeShopDbContext context)
        {
            if (!context.Accounts.Any())
                SeedAccount(context);



            SeedProduct(context);
            base.Seed(context);
        }

        private void SeedAccount(CoffeShopDbContext context)
        {
            IList<Account> AccountList = new List<Account>();
            AccountList.Add(new Account() { AccountID = 1, UserName = "Admin", Password = Encryptor.MD5Hash("conga"), Email = "Admin@gmail.com", UserType="Admin"});
            context.Accounts.AddRange(AccountList);
        }
        private void SeedProduct(CoffeShopDbContext context)
        {
            IList<Product> ProductList = new List<Product>();
            byte[] imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\OneDrive\Máy tính\Img\Chocolate-Avocado-Smoothie-Topped-with-Affogato-683x1024.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Affogato on Avocado Smoothie",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 30,
                Description = "small avocado, pit removed condensed milk, adjust to taste water ice cubes chocolate syrup,chocolate condensed milk for drizzle...",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\OneDrive\Máy tính\Img\Affogato-coffee-3.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Coffee Affogato",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 30,
                Description = "Coffee Jelly Strong Hot Coffee Gelatin Powder Cold Water.Vanilla Ice Cream Caramel Ice Cream Roasted Almonds,Espress...",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\OneDrive\Máy tính\Img\coconutaffogato.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Coconut Affogato",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 30,
                Description = "scoop Coconut Ice Cream Coffee (w/o) sugar scoop Sugar",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\OneDrive\Máy tính\Img\img_6768.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Oreo Affogato Dessert",
                ProductCategoryId = 1,
                Price = 40000,
                Discount = 30,
                Description = " Oreo (chocolate sandwich cookies) Ice-cream (Vanila, chocolate or coffee).Unsweetened cocoa powder Milk Chocolate syrup",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\OneDrive\Máy tính\Img\Affogato Like Pudding with Egg Whites.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Affogato Like Pudding with Egg Whites",
                ProductCategoryId = 1,
                Price = 50000,
                Discount = 0,
                Description = " Egg white (L) Milk Condensed milk Vanilla essence Instantcoffee - Sugar- Water",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
             imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\OneDrive\Máy tính\Img\coconutaffogato.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Tea Affogato",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 0,
                Description = " scoops Vanilla ice cream Strongly black tea (or green tea or hoji tea)•Toppings such as orange peel, anko,nuts,seeds",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
          
            context.Products.AddRange(ProductList);
        }


    }


}