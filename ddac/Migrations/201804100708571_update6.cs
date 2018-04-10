namespace ddac.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Status", c => c.String());
        }
    }
}
