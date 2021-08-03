namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Rating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Rating");
        }
    }
}
