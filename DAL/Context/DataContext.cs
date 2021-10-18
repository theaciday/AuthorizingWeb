using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusLay.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Image> Image { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Password).IsUnique(); });
            modelBuilder.Entity<User>(entity => { entity.HasIndex(e => e.Username).IsUnique(); });
            modelBuilder.Entity<Product>().HasMany(x => x.Categories).WithMany(x => x.Products);
            modelBuilder.Entity<Product>().HasMany(x => x.Images).WithOne(x => x.Product);
            modelBuilder.Entity<ProductImage>().HasOne(x => x.ProductImgEntity).WithOne(x => x.ImgEntity);
        }

    }
}
