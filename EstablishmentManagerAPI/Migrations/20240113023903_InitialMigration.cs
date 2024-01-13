using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstablishmentManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Credit_on_establishment = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Debit_on_establishment = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Deliverys",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_deliveryman_employee = table.Column<int>(type: "int", nullable: false),
                    Id_client = table.Column<int>(type: "int", nullable: false),
                    Tax_value = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creation_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time_deliveryman_arrived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schedule_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverys", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sell_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    StockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_product = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Added_to_stock = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    TableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usage_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Initial_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time_spent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.TableId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_permission = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Client_Addresses",
                columns: table => new
                {
                    Client_addressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Street_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Addresses", x => x.Client_addressId);
                    table.ForeignKey(
                        name: "FK_Client_Addresses_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client_Telephones",
                columns: table => new
                {
                    Client_telephoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creation_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Telephones", x => x.Client_telephoneId);
                    table.ForeignKey(
                        name: "FK_Client_Telephones_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Group_of_products",
                columns: table => new
                {
                    Group_of_productId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromotionId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Sell_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_of_products", x => x.Group_of_productId);
                    table.ForeignKey(
                        name: "FK_Group_of_products_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    Table_id = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    Id_table = table.Column<int>(type: "int", nullable: false),
                    Id_delivery = table.Column<int>(type: "int", nullable: false),
                    Client_name_note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Deliverys_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "Deliverys",
                        principalColumn: "DeliveryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "TableId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
                    table.ForeignKey(
                        name: "FK_Permissions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group_of_productId = table.Column<int>(type: "int", nullable: false),
                    PromotionId = table.Column<int>(type: "int", nullable: false), 
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Sell_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Group_of_products_Group_of_productId",
                        column: x => x.Group_of_productId,
                        principalTable: "Group_of_products",
                        principalColumn: "Group_of_productId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.NoAction); // Edited
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    Order_id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Payment_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment_info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_addons",
                columns: table => new
                {
                    Product_addonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Sell_price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_addons", x => x.Product_addonId);
                    table.ForeignKey(
                        name: "FK_Product_addons_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product_observations",
                columns: table => new
                {
                    Product_observationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_observations", x => x.Product_observationId);
                    table.ForeignKey(
                        name: "FK_Product_observations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_Addresses_ClientId",
                table: "Client_Addresses",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_Telephones_ClientId",
                table: "Client_Telephones",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_of_products_PromotionId",
                table: "Group_of_products",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TransactionId",
                table: "Payments",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_UserId",
                table: "Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_addons_ProductId",
                table: "Product_addons",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_observations_ProductId",
                table: "Product_observations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Group_of_productId",
                table: "Products",
                column: "Group_of_productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PromotionId",
                table: "Products",
                column: "PromotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client_Addresses");

            migrationBuilder.DropTable(
                name: "Client_Telephones");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Product_addons");

            migrationBuilder.DropTable(
                name: "Product_observations");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Deliverys");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Group_of_products");

            migrationBuilder.DropTable(
                name: "Promotions");
        }
    }
}
