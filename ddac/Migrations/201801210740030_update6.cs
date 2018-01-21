namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ShippingAddress_Postcode", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "ShippingAddress_City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "ShippingAddress_StateOrProvince", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "ShippingAddress_Country", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "ShippingAddress_Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ShippingAddress_Street", c => c.String());
            AlterColumn("dbo.Customers", "ShippingAddress_Country", c => c.String());
            AlterColumn("dbo.Customers", "ShippingAddress_StateOrProvince", c => c.String());
            AlterColumn("dbo.Customers", "ShippingAddress_City", c => c.String());
            DropColumn("dbo.Customers", "ShippingAddress_Postcode");
        }
    }
}
