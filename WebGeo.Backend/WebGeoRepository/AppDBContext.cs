using Microsoft.EntityFrameworkCore;
using WebGeoInfrastructure.Entities;

namespace WebGeoRepository
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("postgis");

            modelBuilder.Entity<Client>(a =>
            {
                a.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Product>(a =>
            {
                a.HasKey(e => e.Id);

                a.HasMany(e => e.Orders)
                .WithMany(e => e.Products)
                .UsingEntity<ProductOrder>();

                a.HasMany(e => e.Shops)
                .WithMany(e => e.Products)
                .UsingEntity<ProductShop>();

                a.HasMany(e => e.Storages)
                .WithMany(e => e.Products)
                .UsingEntity<ProductStorage>();
            });

            modelBuilder.Entity<Order>(a =>
            {
                a.HasKey(e => e.Id);

                a.HasOne(e => e.Shop)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ShopId);

                a.HasOne(e => e.Client)
               .WithMany(e => e.Orders)
               .HasForeignKey(e => e.ClientId);


            });
            modelBuilder.Entity<Shop>(a =>
            {
                a.HasKey(e => e.Id);


                a.Property(b => b.Location).HasColumnType("geometry(Point, 4326)");

            });
            modelBuilder.Entity<Storage>(a =>
            {
                a.HasKey(e => e.Id);

                a.Property(b => b.Location).HasColumnType("geometry(Point, 4326)");
            });
            modelBuilder.Entity<ProductOrder>(a =>
            {
                a.HasKey(e => e.Id);

                a.Property(e => e.InShop).HasDefaultValue(true);
            });
            modelBuilder.Entity<ProductShop>(a =>
            {
                a.HasKey(e => e.Id);
            });

            modelBuilder.Entity<ProductStorage>(a =>
            {
                a.HasKey(e => e.Id);
            });



        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<ProductOrder> ProductOrders { get; set; }
        public virtual DbSet<ProductShop> ProductShops { get; set; }
        public virtual DbSet<ProductStorage> ProductStorages { get; set; }


    }
}
