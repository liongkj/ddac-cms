namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CusId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        UserType = c.String(),
                        Name = c.String(nullable: false),
                        Agent_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.CusId)
                .ForeignKey("dbo.Users", t => t.Agent_UserId)
                .Index(t => t.Agent_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Agent_UserId", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "Agent_UserId" });
            DropTable("dbo.Customers");
        }
    }
}
