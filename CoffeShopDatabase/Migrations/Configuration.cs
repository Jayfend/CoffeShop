namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Utilities;

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


            

            base.Seed(context);
        }

        private void SeedAccount(CoffeShopDbContext context)
        {
            IList<Account> AccountList = new List<Account>();
            AccountList.Add(new Account() { AccountID = 2, UserName = "Tester", Password = Encryptor.MD5Hash("1234576"), Email = "conheo@gmail.com"});
            context.Accounts.AddRange(AccountList);
        }
    }
    
    
}
