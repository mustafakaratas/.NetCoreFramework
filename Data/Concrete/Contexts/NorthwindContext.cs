using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> ProductSet { get; set; }
        public DbSet<Category> CategorySet { get; set; }
        public DbSet<User> UserSet { get; set; }
        public DbSet<OperationClaim> OperationClaimSet { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaimSet { get; set; }
    }
}
