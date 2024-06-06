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

                a.HasOne(e => e.StorageRestock)
                .WithMany(a => a.OrderRestocked)
                .HasForeignKey(a => a.StorageRestockId);


            });
            modelBuilder.Entity<Shop>(a =>
            {
                a.HasKey(e => e.Id);

                a.HasOne(e => e.Locality)
                .WithMany(e => e.Shops)
                .HasForeignKey(e => e.LocalityId);

            });
            modelBuilder.Entity<Storage>(a =>
            {
                a.HasKey(e => e.Id);

                a.HasOne(e => e.Locality)
                 .WithMany(e => e.Storages)
                 .HasForeignKey(e => e.LocalityId);
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


            modelBuilder.Entity<Locality>(a =>
            {
                a.HasKey(e => e.Id);

                a.Property(b => b.Location).HasColumnType("geometry(Point, 3763)");

            });

            modelBuilder.Entity<Routes>(a =>
            {
                a.HasKey(e => e.Id);

                a.HasOne(e => e.Origin)
                .WithMany(e => e.OriginList)
                .HasForeignKey(e => e.OriginId);

                a.HasOne(e => e.Destiny)
                .WithMany(e => e.DestinyList)
                .HasForeignKey(e => e.DestinyId);

                a.Property(b => b.Geom).HasColumnType("geometry(LINESTRING, 3763)");

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
        public virtual DbSet<Locality> Localities { get; set; }
        public virtual DbSet<Routes> Routes { get; set; }




    }
}
