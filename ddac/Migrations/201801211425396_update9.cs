namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Agent_UserId", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "Agent_UserId" });
            RenameColumn(table: "dbo.Customers", name: "Agent_UserId", newName: "UserId");
            AlterColumn("dbo.Customers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.Users");
            DropIndex("dbo.Customers", new[] { "UserId" });
            AlterColumn("dbo.Customers", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "UserId", newName: "Agent_UserId");
            CreateIndex("dbo.Customers", "Agent_UserId");
            AddForeignKey("dbo.Customers", "Agent_UserId", "dbo.Users", "UserId");
        }
    }
}
