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
        string path = @"C:\Users\Admin\OneDrive\Máy tính\Img\";
        string Avatarpath = @"C:\Users\Admin\source\repos\CoffeShop\CoffeShop\Assets\img\";
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
            byte[] imgdata = System.IO.File.ReadAllBytes(Avatarpath + "Avatar.jpg");
            IList<Account> AccountList = new List<Account>();
            AccountList.Add(new Account() { AccountID = 1, UserName = "Admin", Password = Encryptor.MD5Hash("123456"), Email = "Admin@gmail.com", UserType="Admin",CreatedDate=DateTime.Now,Image=imgdata});
            IList<Profile> ProfileList = new List<Profile>();
            ProfileList.Add(new Profile() { FullName = "", Address = "", PhoneNumber = "", AccountId = 1 });
            context.Accounts.AddRange(AccountList);
            context.Profiles.AddRange(ProfileList);
        }
        private void SeedProduct(CoffeShopDbContext context)
        {
            IList<Product> ProductList = new List<Product>();
            byte[] imgdata = System.IO.File.ReadAllBytes(path + "Chocolate-Avocado-Smoothie-Topped-with-Affogato-683x1024.jpg");
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
            imgdata = System.IO.File.ReadAllBytes(path + "Affogato-coffee-3.jpg");
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
            imgdata = System.IO.File.ReadAllBytes(path + "coconutaffogato.jpg");
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
            imgdata = System.IO.File.ReadAllBytes(path + "img_6768.jpg");
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
            imgdata = System.IO.File.ReadAllBytes(path + "Affogato Like Pudding with Egg Whites.jpg");
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
             imgdata = System.IO.File.ReadAllBytes(path + "coconutaffogato.jpg");
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
            imgdata = System.IO.File.ReadAllBytes(path + "ca-phe-Americano-1.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Coffe Americano",
                ProductCategoryId = 2,
                Price = 40000,
                Discount = 10,
                Description = " An Americano is an espresso-based drink designed to resemble coffee brewed in a drip filter, considered popular in the United States of America",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "ca-phe-Americano-1.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Coffe Americano",
                ProductCategoryId = 2,
                Price = 40000,
                Discount = 10,
                Description = " An Americano is an espresso-based drink designed to resemble coffee brewed in a drip filter, considered popular in the United States of America",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "lattecafe.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Latte Coffe",
                ProductCategoryId = 3,
                Price = 40000,
                Discount = 10,
                Description = "Caffè latte is a coffee-based drink made primarily from espresso and steamed milk. It consists of one-third espresso, two-thirds heated milk and about 1cm of foam",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "itbaleyswebmain.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Baileys Coffee Latte",
                ProductCategoryId = 3,
                Price = 40000,
                Discount = 10,
                Description = "Caffè latte is a coffee-based drink made primarily from espresso and steamed milk. It consists of one-third espresso, two-thirds heated milk and about 1cm of foam",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "thanh-pham-1279.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Dalgona Coffee ",
                ProductCategoryId = 3,
                Price = 60000,
                Discount = 10,
                Description = "Dalgona coffee is a beverage made by whipping equal parts instant coffee powder, sugar, and hot water until it becomes creamy and then adding it to cold or hot milk",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "vietnamese-egg-coffee-3.jpg");
            ProductList.Add(new Product()
            {
                ProductName = " Egg Latte Coffee",
                ProductCategoryId = 3,
                Price = 60000,
                Discount = 10,
                Description = "An egg coffee (Vietnamese: Cà phê trứng) is a Vietnamese drink traditionally prepared with egg yolks, sugar, condensed milk and robusta coffee.",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "cafesocola.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Hot chocolate Coffe",
                ProductCategoryId = 4,
                Price = 60000,
                Discount = 10,
                Description = "The mixture of coffee and chocolate with cinnamon was very good. It was super easy to prepare and an excellent drink for the cold fall and winter days. I used milk, but you might want to use water if the cocoa mix includes dry milk powder",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
          
                imgdata = System.IO.File.ReadAllBytes(path + "capuchino.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Capuchino",
                ProductCategoryId = 4,
                Price = 60000,
                Discount = 10,
                Description = "A cappuccino is a coffee-based drink made primarily from espresso and milk. It consists of one-third espresso, one-third heated milk and one-third milk foam and is generally served in a 6 to 8-ounce cup",
                Image = imgdata,
                CreatedDate = DateTime.Now
            }); 
                 imgdata = System.IO.File.ReadAllBytes(path + "vietnamese-coffee-with-condensed-milk-1.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Vietnamese iced coffee",
                ProductCategoryId = 4,
                Price = 60000,
                Discount = 10,
                Description = " At its simplest, cà phê đá is made using medium to coarse ground dark roast Vietnamese-grown coffee with a small metal Vietnamese drip filter",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "cafe-mocha-nong.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Hot mocha coffe",
                ProductCategoryId = 10,
                Price = 60000,
                Discount = 10,
                Description = " A caffè mocha  is a chocolate-flavoured warm beverage that is a variant of a café latte",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });
            imgdata = System.IO.File.ReadAllBytes(path + "mocha-cookie-frozen-coffee-with-coffee-whipped-cream-recipe-main-photo.jpg");
            ProductList.Add(new Product()
            {
                ProductName = "Mocha Cookie Frozen Coffee with Coffee Whipped Cream",
                ProductCategoryId = 10,
                Price = 60000,
                Discount = 10,
                Description = "Mocha Cookie Frozen Coffee with Coffee Whipped Cream is one of the most well liked of recent trending foods in the world. It’s appreciated by millions every day ",
                Image = imgdata,
                CreatedDate = DateTime.Now
            });

            context.Products.AddRange(ProductList);
        }


    }


}
