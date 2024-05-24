using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyStore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLocateReceiveLaundry = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportAgents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportAgents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laundry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Merchandise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewCurtain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewCurtain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLaundries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeFromLaundry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeToLaundry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLaundries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLaundries_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLaundry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValue: ""),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 732, DateTimeKind.Utc).AddTicks(1140)),
                    TimeConpletedSewIng = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLaundry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLaundry_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSell",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValue: ""),
                    ValueDate = table.Column<DateTime>(type: "datetime2", maxLength: 20, nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 731, DateTimeKind.Utc).AddTicks(6642)),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, defaultValue: ""),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSell_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceImport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 731, DateTimeKind.Utc).AddTicks(8974)),
                    ImportAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceImport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceImport_ImportAgents_ImportAgentId",
                        column: x => x.ImportAgentId,
                        principalTable: "ImportAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PiceLaundry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 732, DateTimeKind.Utc).AddTicks(4286)),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiceLaundry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiceLaundry_Laundry_LaundryId",
                        column: x => x.LaundryId,
                        principalTable: "Laundry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PiceMerchandise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchandiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceImport = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PriceSell = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 732, DateTimeKind.Utc).AddTicks(5358)),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiceMerchandise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiceMerchandise_Merchandise_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceSewCurtain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SewCurtainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceImport = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    PriceSell = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 732, DateTimeKind.Utc).AddTicks(6536)),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceSewCurtain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceSewCurtain_SewCurtain_SewCurtainId",
                        column: x => x.SewCurtainId,
                        principalTable: "SewCurtain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLaundryDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PriceForOne = table.Column<double>(type: "float", nullable: true),
                    LaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceLaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLaundryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLaundryDetail_InvoiceLaundries_InvoiceLaundryId",
                        column: x => x.InvoiceLaundryId,
                        principalTable: "InvoiceLaundries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceLaundryDetail_Laundry_LaundryId",
                        column: x => x.LaundryId,
                        principalTable: "Laundry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSewCurtainDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceSewCurtainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PriceForOne = table.Column<double>(type: "float", nullable: true),
                    SewCurtainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSewCurtainDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSewCurtainDetails_InvoiceLaundry_InvoiceSewCurtainId",
                        column: x => x.InvoiceSewCurtainId,
                        principalTable: "InvoiceLaundry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceSewCurtainDetails_SewCurtain_SewCurtainId",
                        column: x => x.SewCurtainId,
                        principalTable: "SewCurtain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSellDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceSellId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MerchandiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MerchandiseName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PriceImport = table.Column<double>(type: "float", nullable: true),
                    PriceSell = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSellDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSellDetail_InvoiceSell_InvoiceSellId",
                        column: x => x.InvoiceSellId,
                        principalTable: "InvoiceSell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceSellDetail_Merchandise_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceImportDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceImportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchandiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MerchandiseName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PriceImport = table.Column<double>(type: "float", nullable: true),
                    PriceSell = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceImportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceImportDetail_InvoiceImport_InvoiceImportId",
                        column: x => x.InvoiceImportId,
                        principalTable: "InvoiceImport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceImportDetail_Merchandise_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceLaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceSellId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceImportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceSewCurtainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_InvoiceImport_InvoiceImportId",
                        column: x => x.InvoiceImportId,
                        principalTable: "InvoiceImport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_InvoiceLaundries_InvoiceLaundryId",
                        column: x => x.InvoiceLaundryId,
                        principalTable: "InvoiceLaundries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_InvoiceLaundry_InvoiceSewCurtainId",
                        column: x => x.InvoiceSewCurtainId,
                        principalTable: "InvoiceLaundry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_InvoiceSell_InvoiceSellId",
                        column: x => x.InvoiceSellId,
                        principalTable: "InvoiceSell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentType = table.Column<string>(type: "Nvarchar", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 5, 24, 17, 5, 7, 732, DateTimeKind.Utc).AddTicks(3258)),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, defaultValue: ""),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentDetail_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceImport_ImportAgentId",
                table: "InvoiceImport",
                column: "ImportAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceImportDetail_InvoiceImportId",
                table: "InvoiceImportDetail",
                column: "InvoiceImportId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceImportDetail_MerchandiseId",
                table: "InvoiceImportDetail",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundries_CustomerId",
                table: "InvoiceLaundries",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundry_CustomerId",
                table: "InvoiceLaundry",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundryDetail_InvoiceLaundryId",
                table: "InvoiceLaundryDetail",
                column: "InvoiceLaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundryDetail_LaundryId",
                table: "InvoiceLaundryDetail",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSell_CustomerId",
                table: "InvoiceSell",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellDetail_InvoiceSellId",
                table: "InvoiceSellDetail",
                column: "InvoiceSellId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellDetail_MerchandiseId",
                table: "InvoiceSellDetail",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSewCurtainDetails_InvoiceSewCurtainId",
                table: "InvoiceSewCurtainDetails",
                column: "InvoiceSewCurtainId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSewCurtainDetails_SewCurtainId",
                table: "InvoiceSewCurtainDetails",
                column: "SewCurtainId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceImportId",
                table: "Payment",
                column: "InvoiceImportId",
                unique: true,
                filter: "[InvoiceImportId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceLaundryId",
                table: "Payment",
                column: "InvoiceLaundryId",
                unique: true,
                filter: "[InvoiceLaundryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceSellId",
                table: "Payment",
                column: "InvoiceSellId",
                unique: true,
                filter: "[InvoiceSellId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_InvoiceSewCurtainId",
                table: "Payment",
                column: "InvoiceSewCurtainId",
                unique: true,
                filter: "[InvoiceSewCurtainId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_PaymentId",
                table: "PaymentDetail",
                column: "PaymentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetail_UserId",
                table: "PaymentDetail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PiceLaundry_LaundryId",
                table: "PiceLaundry",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_PiceMerchandise_MerchandiseId",
                table: "PiceMerchandise",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceSewCurtain_SewCurtainId",
                table: "PriceSewCurtain",
                column: "SewCurtainId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceImportDetail");

            migrationBuilder.DropTable(
                name: "InvoiceLaundryDetail");

            migrationBuilder.DropTable(
                name: "InvoiceSellDetail");

            migrationBuilder.DropTable(
                name: "InvoiceSewCurtainDetails");

            migrationBuilder.DropTable(
                name: "PaymentDetail");

            migrationBuilder.DropTable(
                name: "PiceLaundry");

            migrationBuilder.DropTable(
                name: "PiceMerchandise");

            migrationBuilder.DropTable(
                name: "PriceSewCurtain");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Laundry");

            migrationBuilder.DropTable(
                name: "Merchandise");

            migrationBuilder.DropTable(
                name: "SewCurtain");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "InvoiceImport");

            migrationBuilder.DropTable(
                name: "InvoiceLaundries");

            migrationBuilder.DropTable(
                name: "InvoiceLaundry");

            migrationBuilder.DropTable(
                name: "InvoiceSell");

            migrationBuilder.DropTable(
                name: "ImportAgents");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
