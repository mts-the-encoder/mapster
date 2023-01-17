using MapsterDotNet.Entities;
using Microsoft.EntityFrameworkCore;

namespace MapsterDotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BarberShop> BarberShops { get; set; }

    }
}
