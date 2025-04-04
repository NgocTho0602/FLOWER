﻿// <auto-generated />
using System;
using FlowerAppAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FlowerAppAPI.Migrations
{
    [DbContext(typeof(FlowerShopDbContext))]
    [Migration("20241225151609_category")]
    partial class category
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");

                    b.ToTable("AspNetUserRoles", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedName" }, "RoleNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedName] IS NOT NULL)");

                    b.ToTable("AspNetRoles", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "RoleId" }, "IX_AspNetRoleClaims_RoleId");

                    b.ToTable("AspNetRoleClaims", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Initials")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NormalizedEmail" }, "EmailIndex");

                    b.HasIndex(new[] { "NormalizedUserName" }, "UserNameIndex")
                        .IsUnique()
                        .HasFilter("([NormalizedUserName] IS NOT NULL)");

                    b.ToTable("AspNetUsers", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserClaims_UserId");

                    b.ToTable("AspNetUserClaims", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex(new[] { "UserId" }, "IX_AspNetUserLogins_UserId");

                    b.ToTable("AspNetUserLogins", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "identity");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Cart", b =>
                {
                    b.Property<long>("Idcart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDCart");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idcart"));

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime");

                    b.Property<long>("Idproduct")
                        .HasColumnType("bigint")
                        .HasColumnName("IDProduct");

                    b.Property<string>("Iduser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDUser");

                    b.Property<long?>("Quanlity")
                        .HasColumnType("bigint");

                    b.HasKey("Idcart")
                        .HasName("pk_CART");

                    b.HasIndex("Idproduct");

                    b.HasIndex("Iduser");

                    b.ToTable("CART", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Category", b =>
                {
                    b.Property<long>("Idcategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idcategory"));

                    b.Property<string>("Description")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Idcategory")
                        .HasName("pk_CATEGORIES");

                    b.ToTable("CATEGORIES", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Image", b =>
                {
                    b.Property<long>("Idimage")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDImage");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idimage"));

                    b.Property<long>("Idproduct")
                        .HasColumnType("bigint")
                        .HasColumnName("IDProduct");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Idimage")
                        .HasName("pk_IMAGE");

                    b.HasIndex("Idproduct");

                    b.ToTable("IMAGE", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Inventory", b =>
                {
                    b.Property<long>("Idinventory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDInventory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idinventory"));

                    b.Property<long>("Idproduct")
                        .HasColumnType("bigint")
                        .HasColumnName("IDProduct");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime");

                    b.Property<long?>("Quanlity")
                        .HasColumnType("bigint");

                    b.HasKey("Idinventory")
                        .HasName("pk_INVENTORY");

                    b.HasIndex("Idproduct");

                    b.ToTable("INVENTORY", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Invoice", b =>
                {
                    b.Property<long>("Idinvoice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDInvoice");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idinvoice"));

                    b.Property<DateTime?>("BillingDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<long>("Idorder")
                        .HasColumnType("bigint")
                        .HasColumnName("IDOrder");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(10, 0)");

                    b.HasKey("Idinvoice")
                        .HasName("pk_INVOICE");

                    b.HasIndex("Idorder");

                    b.ToTable("INVOICE", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Order", b =>
                {
                    b.Property<long>("Idorder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDOrder");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idorder"));

                    b.Property<long>("Idinvoice")
                        .HasColumnType("bigint")
                        .HasColumnName("IDInvoice");

                    b.Property<long>("Idship")
                        .HasColumnType("bigint")
                        .HasColumnName("IDShip");

                    b.Property<long>("Idstatus")
                        .HasColumnType("bigint")
                        .HasColumnName("IDStatus");

                    b.Property<string>("Iduser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDUser");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(10, 0)");

                    b.HasKey("Idorder")
                        .HasName("pk_ORDER");

                    b.HasIndex("Iduser");

                    b.ToTable("ORDER", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.OrderDetail", b =>
                {
                    b.Property<long>("Idproduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDProduct");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idproduct"));

                    b.Property<long>("Idorder")
                        .HasColumnType("bigint")
                        .HasColumnName("IDOrder");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<long?>("Quanlity")
                        .HasColumnType("bigint");

                    b.HasKey("Idproduct", "Idorder")
                        .HasName("pk_ORDER_DETAIL");

                    b.HasIndex("Idorder");

                    b.ToTable("ORDER_DETAIL", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Payment", b =>
                {
                    b.Property<long>("Idpayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDPayment");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idpayment"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<long>("Idorder")
                        .HasColumnType("bigint")
                        .HasColumnName("IDOrder");

                    b.Property<string>("Iduser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("IDUser");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("RefundAmount")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<DateTime?>("RefundDate")
                        .HasColumnType("datetime");

                    b.HasKey("Idpayment")
                        .HasName("pk_PAYMENT");

                    b.HasIndex("Iduser");

                    b.ToTable("PAYMENT", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.PaymentInvoice", b =>
                {
                    b.Property<long>("Idpayment")
                        .HasColumnType("bigint")
                        .HasColumnName("IDPayment");

                    b.Property<long>("Idinvoice")
                        .HasColumnType("bigint")
                        .HasColumnName("IDInvoice");

                    b.Property<decimal>("PaidPayment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(10, 0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("PaidPayment"));

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.HasKey("Idpayment", "Idinvoice")
                        .HasName("pk_PAYMENT_INVOICE");

                    b.HasIndex("Idinvoice");

                    b.ToTable("PAYMENT_INVOICE", (string)null);
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Product", b =>
                {
                    b.Property<long>("Idproduct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("IDProduct");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Idproduct"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint")
                        .HasColumnName("CategoryID");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Image")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(10, 0)");

                    b.Property<long?>("Stock")
                        .HasColumnType("bigint");

                    b.HasKey("Idproduct")
                        .HasName("pk_PRODUCT");

                    b.HasIndex("CategoryId");

                    b.ToTable("PRODUCT", (string)null);
                });

            modelBuilder.Entity("AspNetUserRole", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FlowerAppAPI.Models.AspNetUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetRoleClaim", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetRole", "Role")
                        .WithMany("AspNetRoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUserClaim", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetUser", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUserLogin", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetUser", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUserToken", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetUser", "User")
                        .WithMany("AspNetUserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Cart", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Product", "IdproductNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("Idproduct")
                        .IsRequired()
                        .HasConstraintName("FK_CART_PRODUCT");

                    b.HasOne("FlowerAppAPI.Models.AspNetUser", "IduserNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("Iduser")
                        .IsRequired()
                        .HasConstraintName("FK_CART_AspNetUsers");

                    b.Navigation("IdproductNavigation");

                    b.Navigation("IduserNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Image", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Product", "IdproductNavigation")
                        .WithMany("Images")
                        .HasForeignKey("Idproduct")
                        .IsRequired()
                        .HasConstraintName("FK_IMAGE_PRODUCT");

                    b.Navigation("IdproductNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Inventory", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Product", "IdproductNavigation")
                        .WithMany("Inventories")
                        .HasForeignKey("Idproduct")
                        .IsRequired()
                        .HasConstraintName("FK_INVENTORY_PRODUCT");

                    b.Navigation("IdproductNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Invoice", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Order", "IdorderNavigation")
                        .WithMany("Invoices")
                        .HasForeignKey("Idorder")
                        .IsRequired()
                        .HasConstraintName("FK_INVOICE_ORDER");

                    b.Navigation("IdorderNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Order", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetUser", "IduserNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("Iduser")
                        .IsRequired()
                        .HasConstraintName("FK_ORDER_AspNetUsers");

                    b.Navigation("IduserNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.OrderDetail", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Order", "IdorderNavigation")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Idorder")
                        .IsRequired()
                        .HasConstraintName("FK_ORDER_DETAIL_Order");

                    b.Navigation("IdorderNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Payment", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.AspNetUser", "IduserNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("Iduser")
                        .IsRequired()
                        .HasConstraintName("FK_PAYMENT_AspNetUsers");

                    b.Navigation("IduserNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.PaymentInvoice", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Invoice", "IdinvoiceNavigation")
                        .WithMany("PaymentInvoices")
                        .HasForeignKey("Idinvoice")
                        .IsRequired()
                        .HasConstraintName("FK_PAYMENT_INVOICE_Invoice");

                    b.HasOne("FlowerAppAPI.Models.Payment", "IdpaymentNavigation")
                        .WithMany("PaymentInvoices")
                        .HasForeignKey("Idpayment")
                        .IsRequired()
                        .HasConstraintName("FK_PAYMENT_INVOICE_Payment");

                    b.Navigation("IdinvoiceNavigation");

                    b.Navigation("IdpaymentNavigation");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Product", b =>
                {
                    b.HasOne("FlowerAppAPI.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetRole", b =>
                {
                    b.Navigation("AspNetRoleClaims");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.AspNetUser", b =>
                {
                    b.Navigation("AspNetUserClaims");

                    b.Navigation("AspNetUserLogins");

                    b.Navigation("AspNetUserTokens");

                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Invoice", b =>
                {
                    b.Navigation("PaymentInvoices");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Order", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Payment", b =>
                {
                    b.Navigation("PaymentInvoices");
                });

            modelBuilder.Entity("FlowerAppAPI.Models.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Images");

                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
