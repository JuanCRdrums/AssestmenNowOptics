﻿// <auto-generated />
using AssestmenNowOptics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AssestmenNowOptics.Migrations
{
    [DbContext(typeof(AssesmentDbContext))]
    partial class AssesmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssestmenNowOptics.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AssestmenNowOptics.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"));

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("AssestmenNowOptics.Models.StoreProductMapping", b =>
                {
                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("MappingId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("StoreId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMappings");
                });

            modelBuilder.Entity("AssestmenNowOptics.Models.StoreProductMapping", b =>
                {
                    b.HasOne("AssestmenNowOptics.Models.Product", "Product")
                        .WithMany("storeProductMappings")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AssestmenNowOptics.Models.Store", "Store")
                        .WithMany("storeProductMappings")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("AssestmenNowOptics.Models.Product", b =>
                {
                    b.Navigation("storeProductMappings");
                });

            modelBuilder.Entity("AssestmenNowOptics.Models.Store", b =>
                {
                    b.Navigation("storeProductMappings");
                });
#pragma warning restore 612, 618
        }
    }
}
