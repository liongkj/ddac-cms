namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CusId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Customers", t => t.Customer_CusId)
                .Index(t => t.Customer_CusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Customer_CusId", "dbo.Customers");
            DropIndex("dbo.Items", new[] { "Customer_CusId" });
            DropTable("dbo.Items");
        }
    }
}
