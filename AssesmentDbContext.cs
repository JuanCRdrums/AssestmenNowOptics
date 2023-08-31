using AssestmenNowOptics.Models;
using Microsoft.EntityFrameworkCore;

namespace AssestmenNowOptics
{
    public class AssesmentDbContext: DbContext
    {

        public AssesmentDbContext(DbContextOptions<AssesmentDbContext> options) : base(options)
        {

        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreProductMapping> ProductMappings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StoreProductMapping>()
                .HasKey(mapping => new { mapping.MappingId });

            modelBuilder.Entity<StoreProductMapping>()
                .HasOne(mapping => mapping.Store)
                .WithMany(store => store.storeProductMappings)
                .HasForeignKey(mapping => mapping.StoreId);

            modelBuilder.Entity<StoreProductMapping>()
                .HasOne(mapping => mapping.Product)
                .WithMany(product => product.storeProductMappings)
                .HasForeignKey(mapping => mapping.ProductId);

            modelBuilder.Entity<StoreProductMapping>().Navigation(s => s.Store).UsePropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<StoreProductMapping>().Navigation(s => s.Product).UsePropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Product>().Navigation(s => s.storeProductMappings).UsePropertyAccessMode(PropertyAccessMode.Field);
            modelBuilder.Entity<Store>().Navigation(s => s.storeProductMappings).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
