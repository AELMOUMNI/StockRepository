﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stocking.Infrastruture;

#nullable disable

namespace Stocking.Infrastruture.Migrations
{
    [DbContext(typeof(StockContext))]
    [Migration("20230119183712_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Stocking.Domain.AggregatesModel.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("HT")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("HT");

                    b.Property<bool>("IsTakeAway")
                        .HasColumnType("bit")
                        .HasColumnName("A emporter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("Quantity");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Reference");

                    b.Property<decimal>("TTC")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TTC");

                    b.Property<decimal>("TVA")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TVA");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("Category");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
