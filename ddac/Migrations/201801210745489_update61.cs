namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update61 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ShippingAddress_Postcode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ShippingAddress_Postcode", c => c.Int(nullable: false));
        }
    }
}
