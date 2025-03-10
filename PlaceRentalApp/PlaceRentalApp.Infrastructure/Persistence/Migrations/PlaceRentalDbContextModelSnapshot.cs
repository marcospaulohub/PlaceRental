﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaceRentalApp.Infrastructure.Persistence;

#nullable disable

namespace PlaceRentalApp.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(PlaceRentalDbContext))]
    partial class PlaceRentalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Amenity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPlace")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdPlace");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlace")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPlace");

                    b.HasIndex("IdUser");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PlaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlaceId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Place", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowPets")
                        .HasColumnType("bit");

                    b.Property<int>("AllowedNumberPerson")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirtDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Amenity", b =>
                {
                    b.HasOne("PlaceRentalApp.Core.Entities.Place", null)
                        .WithMany("Amenities")
                        .HasForeignKey("IdPlace")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Book", b =>
                {
                    b.HasOne("PlaceRentalApp.Core.Entities.Place", "Place")
                        .WithMany("Books")
                        .HasForeignKey("IdPlace")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PlaceRentalApp.Core.Entities.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Comment", b =>
                {
                    b.HasOne("PlaceRentalApp.Core.Entities.Place", null)
                        .WithMany("Comments")
                        .HasForeignKey("PlaceId");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Place", b =>
                {
                    b.HasOne("PlaceRentalApp.Core.Entities.User", "User")
                        .WithMany("Places")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("PlaceRentalApp.Core.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("PlaceId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("District")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("District");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ZipCode");

                            b1.HasKey("PlaceId");

                            b1.ToTable("Places");

                            b1.WithOwner()
                                .HasForeignKey("PlaceId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.Place", b =>
                {
                    b.Navigation("Amenities");

                    b.Navigation("Books");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PlaceRentalApp.Core.Entities.User", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Places");
                });
#pragma warning restore 612, 618
        }
    }
}
