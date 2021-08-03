namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemaneServiceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ServiceType", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "ServiceType");
        }
    }
}
