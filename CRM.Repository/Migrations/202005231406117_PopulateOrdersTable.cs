namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateOrdersTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Orders(Name,Type,ClientId,Price,Discount,Required,MaxExpense,OrderDate,DeliveryDate,isDone) VALUES 
                ('Social','1','9','1000','100','900','300','2020-5-1','2020-6-1','false')");
            Sql(@"INSERT INTO Orders(Name,Type,ClientId,Price,Discount,Required,MaxExpense,OrderDate,DeliveryDate,isDone) VALUES 
                ('programming','1','9','1000','100','900','300','2020-5-1','2020-6-1','false')");
        }
        
        public override void Down()
        {
        }
    }
}
