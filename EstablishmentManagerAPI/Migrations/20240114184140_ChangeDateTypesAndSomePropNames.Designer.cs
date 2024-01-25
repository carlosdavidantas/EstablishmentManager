﻿// <auto-generated />
using System;
using EstablishmentManagerAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EstablishmentManagerAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240114184140_ChangeDateTypesAndSomePropNames")]
    partial class ChangeDateTypesAndSomePropNames
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Models.ClientRelated.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<decimal>("Credit_on_establishment")
                        .HasColumnType("decimal");

                    b.Property<decimal>("Debit_on_establishment")
                        .HasColumnType("decimal");

                    b.Property<DateOnly>("Modified_date")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Models.ClientRelated.Client_address", b =>
                {
                    b.Property<int>("Client_addressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Client_addressId"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Modified_date")
                        .HasColumnType("date");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Client_addressId");

                    b.HasIndex("ClientId");

                    b.ToTable("Client_Addresses");
                });

            modelBuilder.Entity("Models.ClientRelated.Client_telephone", b =>
                {
                    b.Property<int>("Client_telephoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Client_telephoneId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Modified_date")
                        .HasColumnType("date");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Client_telephoneId");

                    b.HasIndex("ClientId");

                    b.ToTable("Client_Telephones");
                });

            modelBuilder.Entity("Models.InventoryRelated.Group_of_product", b =>
                {
                    b.Property<int>("Group_of_productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Group_of_productId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost_price")
                        .HasColumnType("decimal");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PromotionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sell_price")
                        .HasColumnType("decimal");

                    b.HasKey("Group_of_productId");

                    b.HasIndex("PromotionId");

                    b.ToTable("Group_of_products");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost_price")
                        .HasColumnType("decimal");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Group_of_productId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PromotionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sell_price")
                        .HasColumnType("decimal");

                    b.HasKey("ProductId");

                    b.HasIndex("Group_of_productId");

                    b.HasIndex("PromotionId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product_addon", b =>
                {
                    b.Property<int>("Product_addonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_addonId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost_price")
                        .HasColumnType("decimal");

                    b.Property<DateOnly>("Creation_dat")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sell_price")
                        .HasColumnType("decimal");

                    b.HasKey("Product_addonId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_addons");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product_observation", b =>
                {
                    b.Property<int>("Product_observationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Product_observationId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Product_observationId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_observations");
                });

            modelBuilder.Entity("Models.InventoryRelated.Promotion", b =>
                {
                    b.Property<int>("PromotionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PromotionId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sell_price")
                        .HasColumnType("decimal");

                    b.HasKey("PromotionId");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("Models.InventoryRelated.Stock", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockId"));

                    b.Property<DateOnly>("Added_to_stock")
                        .HasColumnType("date");

                    b.Property<int>("Id_product")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Models.MoneyRelated.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Order_id")
                        .HasColumnType("int");

                    b.Property<string>("Payment_info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Payment_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal");

                    b.HasKey("PaymentId");

                    b.HasIndex("OrderId");

                    b.HasIndex("TransactionId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Models.MoneyRelated.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<DateOnly>("Hour")
                        .HasColumnType("date");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Models.OrdersRelated.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeliveryId"));

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Creation_time")
                        .HasColumnType("date");

                    b.Property<int>("Id_client")
                        .HasColumnType("int");

                    b.Property<int>("Id_deliveryman_employee")
                        .HasColumnType("int");

                    b.Property<DateTime>("Schedule_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Tax_value")
                        .HasColumnType("decimal");

                    b.Property<DateTime>("Time_deliveryman_arrived")
                        .HasColumnType("datetime2");

                    b.HasKey("DeliveryId");

                    b.ToTable("Deliverys");
                });

            modelBuilder.Entity("Models.OrdersRelated.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Client_name_note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int");

                    b.Property<int>("Id_delivery")
                        .HasColumnType("int");

                    b.Property<int>("Id_table")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.Property<int>("Table_id")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("TableId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Models.OrdersRelated.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<DateTime>("Initial_time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time_spent")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("Usage_date")
                        .HasColumnType("date");

                    b.HasKey("TableId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Models.UserRelated.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateOnly>("Birthday")
                        .HasColumnType("date");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<int>("Id_user")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Models.UserRelated.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PermissionId"));

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Models.UserRelated.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateOnly>("Creation_date")
                        .HasColumnType("date");

                    b.Property<int>("Id_permission")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.ClientRelated.Client_address", b =>
                {
                    b.HasOne("Models.ClientRelated.Client", "Client")
                        .WithMany("Client_addresses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Models.ClientRelated.Client_telephone", b =>
                {
                    b.HasOne("Models.ClientRelated.Client", "Client")
                        .WithMany("Client_telephones")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Models.InventoryRelated.Group_of_product", b =>
                {
                    b.HasOne("Models.InventoryRelated.Promotion", "Promotion")
                        .WithMany("Group_of_products")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product", b =>
                {
                    b.HasOne("Models.InventoryRelated.Group_of_product", "Group_of_product")
                        .WithMany("Products")
                        .HasForeignKey("Group_of_productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.InventoryRelated.Promotion", "Promotion")
                        .WithMany("Products")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group_of_product");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product_addon", b =>
                {
                    b.HasOne("Models.InventoryRelated.Product", "Product")
                        .WithMany("Product_addons")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product_observation", b =>
                {
                    b.HasOne("Models.InventoryRelated.Product", "Product")
                        .WithMany("Product_observations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Models.MoneyRelated.Payment", b =>
                {
                    b.HasOne("Models.OrdersRelated.Order", "Order")
                        .WithMany("Payments")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.MoneyRelated.Transaction", "Transaction")
                        .WithMany("Payments")
                        .HasForeignKey("TransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Models.OrdersRelated.Order", b =>
                {
                    b.HasOne("Models.OrdersRelated.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.OrdersRelated.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Models.UserRelated.Permission", b =>
                {
                    b.HasOne("Models.UserRelated.User", "User")
                        .WithMany("Permissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.ClientRelated.Client", b =>
                {
                    b.Navigation("Client_addresses");

                    b.Navigation("Client_telephones");
                });

            modelBuilder.Entity("Models.InventoryRelated.Group_of_product", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.InventoryRelated.Product", b =>
                {
                    b.Navigation("Product_addons");

                    b.Navigation("Product_observations");
                });

            modelBuilder.Entity("Models.InventoryRelated.Promotion", b =>
                {
                    b.Navigation("Group_of_products");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Models.MoneyRelated.Transaction", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Models.OrdersRelated.Delivery", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.OrdersRelated.Order", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Models.OrdersRelated.Table", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Models.UserRelated.User", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}