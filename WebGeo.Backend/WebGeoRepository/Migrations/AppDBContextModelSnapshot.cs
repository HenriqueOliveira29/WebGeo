﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebGeoRepository;

#nullable disable

namespace WebGeoRepository.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Geometry>("Location")
                        .IsRequired()
                        .HasColumnType("geometry(Point, 3763)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateDeliver")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateDeliverToClient")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("StorageRestockId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ShopId");

                    b.HasIndex("StorageRestockId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("InShop")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true);

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.ProductShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ShopId")
                        .HasColumnType("integer");

                    b.Property<float>("Stock")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShopId");

                    b.ToTable("ProductShops");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.ProductStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<float>("Stock")
                        .HasColumnType("real");

                    b.Property<int>("StorageId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StorageId");

                    b.ToTable("ProductStorages");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Routes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DestinyId")
                        .HasColumnType("integer");

                    b.Property<Geometry>("Geom")
                        .IsRequired()
                        .HasColumnType("geometry(LINESTRING, 3763)");

                    b.Property<int>("OriginId")
                        .HasColumnType("integer");

                    b.Property<int>("Time")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DestinyId");

                    b.HasIndex("OriginId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LocalityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LocalityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocalityId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Order", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGeoInfrastructure.Entities.Shop", "Shop")
                        .WithMany("Orders")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGeoInfrastructure.Entities.Storage", "StorageRestock")
                        .WithMany("OrderRestocked")
                        .HasForeignKey("StorageRestockId");

                    b.Navigation("Client");

                    b.Navigation("Shop");

                    b.Navigation("StorageRestock");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.ProductOrder", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Order", "Order")
                        .WithMany("ProductOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGeoInfrastructure.Entities.Product", "Product")
                        .WithMany("ProductOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.ProductShop", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGeoInfrastructure.Entities.Shop", "Shop")
                        .WithMany("ProductShop")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.ProductStorage", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGeoInfrastructure.Entities.Storage", "Storage")
                        .WithMany("ProductStorages")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Routes", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Locality", "Destiny")
                        .WithMany("DestinyList")
                        .HasForeignKey("DestinyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebGeoInfrastructure.Entities.Locality", "Origin")
                        .WithMany("OriginList")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destiny");

                    b.Navigation("Origin");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Shop", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Locality", "Locality")
                        .WithMany("Shops")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locality");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Storage", b =>
                {
                    b.HasOne("WebGeoInfrastructure.Entities.Locality", "Locality")
                        .WithMany("Storages")
                        .HasForeignKey("LocalityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locality");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Locality", b =>
                {
                    b.Navigation("DestinyList");

                    b.Navigation("OriginList");

                    b.Navigation("Shops");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Order", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Product", b =>
                {
                    b.Navigation("ProductOrders");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Shop", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductShop");
                });

            modelBuilder.Entity("WebGeoInfrastructure.Entities.Storage", b =>
                {
                    b.Navigation("OrderRestocked");

                    b.Navigation("ProductStorages");
                });
#pragma warning restore 612, 618
        }
    }
}
