namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetTypeLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(maxLength: 120));
            AlterColumn("dbo.Clients", "Phone1", c => c.String(maxLength: 15));
            AlterColumn("dbo.Clients", "Phone2", c => c.String(maxLength: 15));
            AlterColumn("dbo.Clients", "City", c => c.String(maxLength: 25));
            AlterColumn("dbo.Clients", "Address", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "Address", c => c.String());
            AlterColumn("dbo.Clients", "City", c => c.String());
            AlterColumn("dbo.Clients", "Phone2", c => c.String());
            AlterColumn("dbo.Clients", "Phone1", c => c.String());
            AlterColumn("dbo.Clients", "Name", c => c.String());
        }
    }
}
