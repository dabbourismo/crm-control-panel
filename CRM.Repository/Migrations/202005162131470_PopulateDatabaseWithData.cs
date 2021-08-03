namespace CRM.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDatabaseWithData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Clients(Name,Speciality,Company,Phone1,Phone2,City,Address) VALUES 
                ('Mohamed Dabbour','Engineer','Adlink','01149219212','01020925337','Damanhour','Fkria street')");

            Sql(@"INSERT INTO Clients(Name,Speciality,Company,Phone1,Phone2,City,Address) VALUES 
                ('Hossam','Engineer','Adlink','01149219212','01020925337','Damanhour','Fkria street')");

            Sql(@"INSERT INTO Clients(Name,Speciality,Company,Phone1,Phone2,City,Address) VALUES 
                ('Gado','Engineer','Adlink','01149219212','01020925337','Damanhour','Fkria street')");
        }
        
        public override void Down()
        {
            Sql(@"DELETE FROM Clients");
        }
    }
}
