namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductRequiredUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Image", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Image", c => c.Binary());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
        }
    }
}
