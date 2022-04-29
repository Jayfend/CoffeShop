namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Discount", c => c.Single(nullable: false));
        }
    }
}
