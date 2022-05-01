namespace CoffeShopDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressPhoneRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "PhoneNumber");
            DropColumn("dbo.Orders", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Address", c => c.String());
            AddColumn("dbo.Orders", "PhoneNumber", c => c.Int(nullable: false));
        }
    }
}
