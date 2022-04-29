namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                        TotalPrice = c.Double(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Orders", new[] { "AccountID" });
            DropTable("dbo.Orders");
        }
    }
}
