using Microsoft.EntityFrameworkCore;
using SA.Model.Entities;

namespace SA.DataAccess.EF.Context
{
    public class NorthwindContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\;database=Northwind;trusted_connection=true;");
        }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Employee>? Employees { get; set; }


    }
}
