namespace CoffeShopDatabase.Migrations
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
            AccountList.Add(new Account() { AccountID = 1, UserName = "Tester", Password = Encryptor.MD5Hash("1234576"), Email = "conheo@gmail.com" });
            context.Accounts.AddRange(AccountList);
        }
        private void SeedProduct(CoffeShopDbContext context)
        {
            IList<Product> ProductList = new List<Product>();
            byte[] imgdata = System.IO.File.ReadAllBytes(@"C:\Users\Admin\source\repos\CoffeShop\CoffeShop\Assets\img\menu-1.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Trà Sữa Trân Châu",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 0.3,
                Description = "Trà sữa trân châu đường đen ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Trà Sữa Thái",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 0.3,
                Description = "Trà sữa trân châu đường đen ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Mi Lô Dầm",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 0.3,
                Description = "Trà sữa trân châu đường đen ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Sữa tươi trân châu đường đen",
                ProductCategoryId = 1,
                Price = 30000,
                Discount = 0.3,
                Description = "Trà sữa trân châu đường đen ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Bánh kem tươi socola",
                ProductCategoryId = 2,
                Price = 30000,
                Discount = 0.3,
                Description = "Bánh kem ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Bánh kem tươi socola",
                ProductCategoryId = 2,
                Price = 30000,
                Discount = 0.3,
                Description = "Bánh kem ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Bánh kem tươi socola",
                ProductCategoryId = 2,
                Price = 30000,
                Discount = 0.3,
                Description = "Bánh kem ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            ProductList.Add(new Product()
            {
                ProductName = "Bánh Matcha",
                ProductCategoryId = 3,
                Price = 30000,
                Discount = 0.3,
                Description = "Bánh kem ăn vô ngon xỉu",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            context.Products.AddRange(ProductList);
        }

        
    }


}
