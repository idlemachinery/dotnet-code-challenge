using Microsoft.EntityFrameworkCore;
using PetStore.Core.Entities;

namespace PetStore.Data
{
    public class PetStoreContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public PetStoreContext(DbContextOptions<PetStoreContext> options) : base(options)
        {
        }
    }
}
