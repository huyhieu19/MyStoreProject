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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Laundries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laundries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetailEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    PaymentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetailEntity", x => x.Id);
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
                name: "PriceLaundryEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LaundryEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLaundryEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceLaundryEntity_Laundries_LaundryEntityId",
                        column: x => x.LaundryEntityId,
                        principalTable: "Laundries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceLaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPayment = table.Column<bool>(type: "bit", nullable: false),
                    PaymentDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_PaymentDetailEntity_PaymentDetailId",
                        column: x => x.PaymentDetailId,
                        principalTable: "PaymentDetailEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_Users_PaymentDetailEntity_PaymentDetailId",
                        column: x => x.PaymentDetailId,
                        principalTable: "PaymentDetailEntity",
                        principalColumn: "Id");
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
                name: "InvoiceImports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImportAgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImportAgentEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceImports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceImports_ImportAgents_ImportAgentEntityId",
                        column: x => x.ImportAgentEntityId,
                        principalTable: "ImportAgents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceImports_Payments_PaymentsId",
                        column: x => x.PaymentsId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLaundries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeFromLaundry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeToLaundry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLaundries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLaundries_Customers_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLaundries_Payments_PaymentsId",
                        column: x => x.PaymentsId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSells",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSells_Customers_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceSells_Payments_PaymentsId",
                        column: x => x.PaymentsId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSewCurtains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeConpletedSewIng = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSewCurtains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSewCurtains_Customers_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceSewCurtains_Payments_PaymentsId",
                        column: x => x.PaymentsId,
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Merchandises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceImportEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Merchandises_InvoiceImports_InvoiceImportEntityId",
                        column: x => x.InvoiceImportEntityId,
                        principalTable: "InvoiceImports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLaundryDetailsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceSellId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    LaundryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceLaundryEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLaundryDetailsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLaundryDetailsEntity_InvoiceLaundries_InvoiceLaundryEntityId",
                        column: x => x.InvoiceLaundryEntityId,
                        principalTable: "InvoiceLaundries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLaundryDetailsEntity_Laundries_LaundryId",
                        column: x => x.LaundryId,
                        principalTable: "Laundries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSellDetailsEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceSellId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    MerchandiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceSellEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvoiceSewCurtainEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSellDetailsEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSellDetailsEntity_InvoiceSells_InvoiceSellEntityId",
                        column: x => x.InvoiceSellEntityId,
                        principalTable: "InvoiceSells",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceSellDetailsEntity_InvoiceSewCurtains_InvoiceSewCurtainEntityId",
                        column: x => x.InvoiceSewCurtainEntityId,
                        principalTable: "InvoiceSewCurtains",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceSellDetailsEntity_Merchandises_MerchandiseId",
                        column: x => x.MerchandiseId,
                        principalTable: "Merchandises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceMerchandiseEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MerchandiseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceImport = table.Column<double>(type: "float", nullable: false),
                    PriceSell = table.Column<double>(type: "float", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MerchandiseEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMerchandiseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceMerchandiseEntity_Merchandises_MerchandiseEntityId",
                        column: x => x.MerchandiseEntityId,
                        principalTable: "Merchandises",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceImports_ImportAgentEntityId",
                table: "InvoiceImports",
                column: "ImportAgentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceImports_PaymentsId",
                table: "InvoiceImports",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundries_CustomerEntityId",
                table: "InvoiceLaundries",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundries_PaymentsId",
                table: "InvoiceLaundries",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundryDetailsEntity_InvoiceLaundryEntityId",
                table: "InvoiceLaundryDetailsEntity",
                column: "InvoiceLaundryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLaundryDetailsEntity_LaundryId",
                table: "InvoiceLaundryDetailsEntity",
                column: "LaundryId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellDetailsEntity_InvoiceSellEntityId",
                table: "InvoiceSellDetailsEntity",
                column: "InvoiceSellEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellDetailsEntity_InvoiceSewCurtainEntityId",
                table: "InvoiceSellDetailsEntity",
                column: "InvoiceSewCurtainEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellDetailsEntity_MerchandiseId",
                table: "InvoiceSellDetailsEntity",
                column: "MerchandiseId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSells_CustomerEntityId",
                table: "InvoiceSells",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSells_PaymentsId",
                table: "InvoiceSells",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSewCurtains_CustomerEntityId",
                table: "InvoiceSewCurtains",
                column: "CustomerEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSewCurtains_PaymentsId",
                table: "InvoiceSewCurtains",
                column: "PaymentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Merchandises_InvoiceImportEntityId",
                table: "Merchandises",
                column: "InvoiceImportEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaymentDetailId",
                table: "Payments",
                column: "PaymentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceLaundryEntity_LaundryEntityId",
                table: "PriceLaundryEntity",
                column: "LaundryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMerchandiseEntity_MerchandiseEntityId",
                table: "PriceMerchandiseEntity",
                column: "MerchandiseEntityId");

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
                name: "IX_Users_PaymentDetailId",
                table: "Users",
                column: "PaymentDetailId");

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
                name: "InvoiceLaundryDetailsEntity");

            migrationBuilder.DropTable(
                name: "InvoiceSellDetailsEntity");

            migrationBuilder.DropTable(
                name: "PriceLaundryEntity");

            migrationBuilder.DropTable(
                name: "PriceMerchandiseEntity");

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
                name: "InvoiceLaundries");

            migrationBuilder.DropTable(
                name: "InvoiceSells");

            migrationBuilder.DropTable(
                name: "InvoiceSewCurtains");

            migrationBuilder.DropTable(
                name: "Laundries");

            migrationBuilder.DropTable(
                name: "Merchandises");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "InvoiceImports");

            migrationBuilder.DropTable(
                name: "ImportAgents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PaymentDetailEntity");
        }
    }
}
