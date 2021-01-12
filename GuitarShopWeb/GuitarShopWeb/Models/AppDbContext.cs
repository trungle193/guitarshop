using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
namespace GuitarShopWeb.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>((entity) =>
            {
                entity.ToTable("Category");
                entity.HasOne(c => c.Parent).WithMany(p => p.Childrens).HasForeignKey(x => x.ParentId);
            });
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Page>().ToTable("Page");
        }
    }
}
