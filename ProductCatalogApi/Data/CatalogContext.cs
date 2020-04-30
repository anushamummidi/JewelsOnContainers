using Microsoft.EntityFrameworkCore;
using ProductCatalogApi.Domain_Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogApi.Data
{
    //Colon at Class level is Inheritence
    public class CatalogContext : DbContext
    {
        //Dbcontext's condtructor is being passed by using : at constructor level 
        public CatalogContext(DbContextOptions options)
            :base(options)
        { }
        //CatalogBrands is Database table of type Catalogbrand
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }

        //modelbuilder is going to create tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(e =>
            {
                e.ToTable("CatalogBrands");
                e.Property(b => b.Id)
                   .IsRequired()
                   .UseHiLo("Catalog_brand_hilo");

                e.Property(b => b.Brand)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<CatalogType>(e =>
            {
                e.ToTable("CatalogType");
                e.Property(t => t.Id)
                   .IsRequired()
                   .UseHiLo("Catalog_type_hilo");

                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);
            });
            modelBuilder.Entity<CatalogItem>(e =>
            {
                e.ToTable("Catalog");
                e.Property(c => c.Id)
                   .IsRequired()
                   .UseHiLo("Catalog_hilo");

                e.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(c => c.Price)
                    .IsRequired();

                //foreign key relation
                e.HasOne(c => c.CatalogType)
                    .WithMany()
                    .HasForeignKey(c => c.CatalogTypeId);

                e.HasOne(c => c.CatalogBrand)
                    .WithMany()
                    .HasForeignKey(c => c.CatalogBrandId);


            });

        }
    }
}
