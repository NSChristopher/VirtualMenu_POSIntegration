﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VirtualMenu.Data;

#nullable disable

namespace VirtualMenu.Data.Migrations
{
    [DbContext(typeof(MenuContext))]
    [Migration("20230611201433_descriptionnotrequired")]
    partial class descriptionnotrequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VirtualMenu.Models.Category", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("activeStatus")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("VirtualMenu.Models.Item", b =>
                {
                    b.Property<string>("itemId")
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<bool>("activeStatus")
                        .HasColumnType("bit");

                    b.Property<string>("categoryid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastAccessed")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("itemId");

                    b.HasIndex("categoryid");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("VirtualMenu.Models.ServingSizePrice", b =>
                {
                    b.Property<string>("servingSizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<string>("itemId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("orderSequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priceStr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("servingSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("servingSizeId");

                    b.HasIndex("itemId");

                    b.ToTable("ServingSizePrices");
                });

            modelBuilder.Entity("VirtualMenu.Models.Item", b =>
                {
                    b.HasOne("VirtualMenu.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("VirtualMenu.Models.ServingSizePrice", b =>
                {
                    b.HasOne("VirtualMenu.Models.Item", null)
                        .WithMany("servingSizePrices")
                        .HasForeignKey("itemId");
                });

            modelBuilder.Entity("VirtualMenu.Models.Item", b =>
                {
                    b.Navigation("servingSizePrices");
                });
#pragma warning restore 612, 618
        }
    }
}
