using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repository.Models
{
    public partial class MarketPartiesContext : DbContext
    {
        public MarketPartiesContext(DbContextOptions<MarketPartiesContext> options) : base(options)
        {
        }

        public DbSet<Retailer> Retailers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Retailer>().ToTable(tb => tb.HasTrigger("UpdateDateTimeRetailer"));
        }
    }
}
