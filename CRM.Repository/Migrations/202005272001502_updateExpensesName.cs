namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateExpensesName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CompanyExpenses", "ExpenseType", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyExpenses", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CompanyExpenses", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.CompanyExpenses", "ExpenseType");
        }
    }
}
