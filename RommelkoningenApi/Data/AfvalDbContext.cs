using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RommelkoningenApi.Models;
using RommelkoningenApi.Configurations;

namespace RommelkoningenApi.Data
{
    public class AfvalDbContext : DbContext
    {
        public AfvalDbContext(DbContextOptions<AfvalDbContext> options) : base(options) { }

        public DbSet<AfvalData> AfvalData { get; set; }
        public DbSet<FotoData> FotoData { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<FotoData>()
            //.HasMany<AfvalData>()
            //.WithOne();
            modelBuilder.ApplyConfiguration(new FotoDataConfiguration());
            modelBuilder.ApplyConfiguration(new AfvalDataConfiguration());
            //modelBuilder.Entity<AfvalData>().ToTable("AfvalData");
            //modelBuilder.Entity<FotoData>().ToTable("FotoData");
        }
    }
}
