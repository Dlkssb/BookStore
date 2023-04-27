﻿// <auto-generated />
using System;
using BookStore.Infrastructrue.Presistince;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStore.Infrastructrue.Migrations
{
    [DbContext(typeof(BookDbContext))]
    [Migration("20230427234022_intia3")]
    partial class intia3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStore.Domin.Entity.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int?>("ShelfId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShelfId");

                    b.HasIndex("ShelfId1");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookStore.Domin.Entity.Rack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("BookStore.Domin.Entity.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("RackId")
                        .HasColumnType("int");

                    b.Property<int?>("RackId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RackId");

                    b.HasIndex("RackId1");

                    b.ToTable("Shelves");
                });

            modelBuilder.Entity("BookStore.Domin.Entity.Book", b =>
                {
                    b.HasOne("BookStore.Domin.Entity.Shelf", "Shelf")
                        .WithMany()
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Domin.Entity.Shelf", null)
                        .WithMany("Books")
                        .HasForeignKey("ShelfId1");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("BookStore.Domin.Entity.Shelf", b =>
                {
                    b.HasOne("BookStore.Domin.Entity.Rack", "Rack")
                        .WithMany()
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStore.Domin.Entity.Rack", null)
                        .WithMany("Shelves")
                        .HasForeignKey("RackId1");

                    b.Navigation("Rack");
                });

            modelBuilder.Entity("BookStore.Domin.Entity.Rack", b =>
                {
                    b.Navigation("Shelves");
                });

            modelBuilder.Entity("BookStore.Domin.Entity.Shelf", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
