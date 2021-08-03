namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameExpensesType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderExpenses", "ExpenseType", c => c.Int(nullable: false));
            DropColumn("dbo.OrderExpenses", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderExpenses", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.OrderExpenses", "ExpenseType");
        }
    }
}
