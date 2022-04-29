namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedDateUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CreatedDate");
        }
    }
}
