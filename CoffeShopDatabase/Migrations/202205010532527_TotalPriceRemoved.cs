namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalPriceRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "TotalPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
    }
}
