namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountID = c.Int(nullable: false, identity: true),
                        UserType = c.String(nullable: false, maxLength: 40),
                        UserName = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.AccountID);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillID = c.Int(nullable: false, identity: true),
                        TotalPrice = c.Double(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Purchasedate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BillID)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 255),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Message = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        Description = c.String(nullable: false),
                        Image = c.Binary(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Bills", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "AccountID", "dbo.Accounts");
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "AccountID" });
            DropIndex("dbo.Bills", new[] { "OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Contacts");
            DropTable("dbo.Orders");
            DropTable("dbo.Bills");
            DropTable("dbo.Accounts");
        }
    }
}
