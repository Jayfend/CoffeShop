namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "AccountID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "AccountID");
            AddForeignKey("dbo.Orders", "AccountID", "dbo.Accounts", "AccountID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Orders", new[] { "AccountID" });
            DropColumn("dbo.Orders", "AccountID");
        }
    }
}
