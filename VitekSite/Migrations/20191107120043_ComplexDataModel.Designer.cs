﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitekSite.Data;

namespace VitekSite.Migrations
{
    [DbContext(typeof(BussinessContext))]
    [Migration("20191107120043_ComplexDataModel")]
    partial class ComplexDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VitekSite.Models.CountryAssignment", b =>
                {
                    b.Property<int>("ProductGuideID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProductGuideID");

                    b.ToTable("CountryAssignment");
                });

            modelBuilder.Entity("VitekSite.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("SubscriptionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("VitekSite.Models.Market", b =>
                {
                    b.Property<int>("MarketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ProductGuideID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MarketID");

                    b.HasIndex("ProductGuideID");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("VitekSite.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("MarketID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProductID");

                    b.HasIndex("MarketID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("VitekSite.Models.ProductAssignment", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("ProductGuideID")
                        .HasColumnType("int");

                    b.HasKey("ProductID", "ProductGuideID");

                    b.HasIndex("ProductGuideID");

                    b.ToTable("ProductAssignment");
                });

            modelBuilder.Entity("VitekSite.Models.ProductGuide", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("ProductGuide");
                });

            modelBuilder.Entity("VitekSite.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("CustomerLoyalty")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProductID");

                    b.ToTable("Subscription");
                });

            modelBuilder.Entity("VitekSite.Models.CountryAssignment", b =>
                {
                    b.HasOne("VitekSite.Models.ProductGuide", "ProductGuide")
                        .WithOne("CountryAssignment")
                        .HasForeignKey("VitekSite.Models.CountryAssignment", "ProductGuideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VitekSite.Models.Market", b =>
                {
                    b.HasOne("VitekSite.Models.ProductGuide", "Administrator")
                        .WithMany()
                        .HasForeignKey("ProductGuideID");
                });

            modelBuilder.Entity("VitekSite.Models.Product", b =>
                {
                    b.HasOne("VitekSite.Models.Market", "Market")
                        .WithMany("Products")
                        .HasForeignKey("MarketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VitekSite.Models.ProductAssignment", b =>
                {
                    b.HasOne("VitekSite.Models.ProductGuide", "ProductGuide")
                        .WithMany("ProductAssignments")
                        .HasForeignKey("ProductGuideID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitekSite.Models.Product", "Product")
                        .WithMany("ProductAssignments")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VitekSite.Models.Subscription", b =>
                {
                    b.HasOne("VitekSite.Models.Customer", "Customer")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitekSite.Models.Product", "Product")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
