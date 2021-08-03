namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OldOrderTableAdding : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OldOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        OldPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OldOrders", "OrderId", "dbo.Orders");
            DropIndex("dbo.OldOrders", new[] { "OrderId" });
            DropTable("dbo.OldOrders");
        }
    }
}
