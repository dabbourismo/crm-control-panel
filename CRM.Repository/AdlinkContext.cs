
using CRM.Models;
using System.Data.Entity;
using System.Diagnostics;

namespace CRM.Repository
{
    //enable-migrations ==>will check if there is already installed database
    //add-migration {name-of-migration}
    //update-database
    //update-database -script
    //Update-Database -ConnectionStringName "MyConnectionString"
    public class AdlinkContext : DbContext
    {
        public AdlinkContext() : base("name=remote")
        {
            Database.Log = e => Debug.WriteLine(e);
        }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<CompanyExpense> CompanyExpenses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderExpense> OrderExpenses { get; set; }
        public DbSet<OrderRevenue> OrderRevenues { get; set; }
        public DbSet<OldOrder> OldOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<User>();
            //modelBuilder.Entity<Role>();
            //modelBuilder.Entity<Team>();
            //base.OnModelCreating(modelBuilder);

            //Map entity to table
            //modelBuilder.Entity<Client>().ToTable("Clients");
           
        }
    }
}
