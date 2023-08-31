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

            // Definir relaciones y claves foráneas
            modelBuilder.Entity<StoreProductMapping>()
                .HasKey(mapping => new { mapping.StoreId, mapping.ProductId });

            modelBuilder.Entity<StoreProductMapping>()
                .HasOne(mapping => mapping.Store)
                .WithMany(store => store.storeProductMappings)
                .HasForeignKey(mapping => mapping.StoreId);

            modelBuilder.Entity<StoreProductMapping>()
                .HasOne(mapping => mapping.Product)
                .WithMany(product => product.storeProductMappings)
                .HasForeignKey(mapping => mapping.ProductId);
        }
    }
}
