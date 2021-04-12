﻿// <auto-generated />
using System;
using CaferiaApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CaferiaApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210114205840_OrderItem123")]
    partial class OrderItem123
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaferiaApp.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("Quantity");

                    b.Property<string>("UniqueToken");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("CaferiaApp.Models.Common.Authentication.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "a682b56a-6135-4111-a0k0-bdec547e3waz",
                            ConcurrencyStamp = "da9a3b0e-8b6f-8529-71d0-4fd255e23f15",
                            CreatedOn = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Has All Permissions",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "d925b59b-7456-1442-d0n0-bdec765e3awv",
                            ConcurrencyStamp = "ea9a3b0f-9b5f-7153-81e0-4fd799e23f17",
                            CreatedOn = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Has Minimum Permissions",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("CaferiaApp.Models.Common.Authentication.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<double>("Balance");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<byte>("Status");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserTypeId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "8ab6ee61-f36c-41b1-ae27-dbb23cbfb507",
                            AccessFailedCount = 0,
                            Balance = 0.0,
                            ConcurrencyStamp = "26d21881-0a3a-44ab-aa4d-10664ace1e2d",
                            Email = "test@mail.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST@MAIL.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEOJVsHUa611Khzkcg/zXgZ8EeegKhZAyW2eVPMzWJiToPuR45aBwuID99TNJ91JPxg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "5TDMS5CNA2GYJK2URB4GDOCQI2NI7EHJ",
                            Status = (byte)1,
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            UserTypeId = 1
                        });
                });

            modelBuilder.Entity("CaferiaApp.Models.Common.Authentication.UserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clinet"
                        });
                });

            modelBuilder.Entity("CaferiaApp.Models.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("CaferiaApp.Models.DeliveryBoy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("IdNo");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PhotoName1");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("DeliveryBoys");
                });

            modelBuilder.Entity("CaferiaApp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripton");

                    b.Property<bool>("IsFeatured");

                    b.Property<bool>("IsInStock");

                    b.Property<int>("ItemCatagoryId");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoName1");

                    b.Property<double>("Price");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ItemCatagoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("CaferiaApp.Models.ItemCatagory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("PhotoName1");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("ItemCatagories");
                });

            modelBuilder.Entity("CaferiaApp.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("City");

                    b.Property<string>("ContactNo");

                    b.Property<string>("Country");

                    b.Property<int?>("CouponId");

                    b.Property<int?>("DeliveryBoyId");

                    b.Property<double>("DiscountAmount");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<double>("NetPayable");

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("OrderStatus");

                    b.Property<int>("OrderType");

                    b.Property<int>("PaymentStatus");

                    b.Property<string>("PinCode");

                    b.Property<string>("Remarks");

                    b.Property<string>("State");

                    b.Property<double>("TotalAmount");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CouponId");

                    b.HasIndex("DeliveryBoyId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CaferiaApp.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemId");

                    b.Property<int>("OrderId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("CaferiaApp.Models.WalletRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Phone");

                    b.Property<string>("Remarks");

                    b.Property<double>("RequestAmount");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("WalletRequests");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "8ab6ee61-f36c-41b1-ae27-dbb23cbfb507",
                            RoleId = "a682b56a-6135-4111-a0k0-bdec547e3waz"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CaferiaApp.Models.CartItem", b =>
                {
                    b.HasOne("CaferiaApp.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaferiaApp.Models.Common.Authentication.ApplicationUser", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.UserType", "UserType")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaferiaApp.Models.Item", b =>
                {
                    b.HasOne("CaferiaApp.Models.ItemCatagory", "ItemCatagory")
                        .WithMany("Items")
                        .HasForeignKey("ItemCatagoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaferiaApp.Models.Order", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CaferiaApp.Models.Coupon", "Coupon")
                        .WithMany()
                        .HasForeignKey("CouponId");

                    b.HasOne("CaferiaApp.Models.DeliveryBoy", "DeliveryBoy")
                        .WithMany()
                        .HasForeignKey("DeliveryBoyId");
                });

            modelBuilder.Entity("CaferiaApp.Models.OrderItem", b =>
                {
                    b.HasOne("CaferiaApp.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaferiaApp.Models.Order", "Order")
                        .WithMany("OrderItem")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaferiaApp.Models.WalletRequest", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CaferiaApp.Models.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
