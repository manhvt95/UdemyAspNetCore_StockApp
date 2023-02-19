﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.Infrastructure;

#nullable disable

namespace StockApp.Infrastructure.Migrations
{
    [DbContext(typeof(StockAppDbContext))]
    [Migration("20230204144336_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockApp.Core.Domain.Entities.BuyOrder", b =>
                {
                    b.Property<Guid>("BuyOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAndTimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuyOrderId");

                    b.ToTable("BuyOrders");
                });

            modelBuilder.Entity("StockApp.Core.Domain.Entities.SellOrder", b =>
                {
                    b.Property<Guid>("SellOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAndTimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SellOrderId");

                    b.ToTable("SellOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
