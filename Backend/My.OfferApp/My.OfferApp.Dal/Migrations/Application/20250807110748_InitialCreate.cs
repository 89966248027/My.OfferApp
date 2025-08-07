using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace My.OfferApp.Dal.Migrations.Application
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.EnsureSchema(
                name: "dict");

            migrationBuilder.CreateSequence<int>(
                name: "OfferId",
                schema: "common");

            migrationBuilder.CreateSequence<int>(
                name: "SupplierId",
                schema: "dict");

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "dict",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR dict.SupplierId"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "common",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR common.OfferId"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalSchema: "dict",
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_SupplierId",
                schema: "common",
                table: "Offer",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer",
                schema: "common");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "dict");

            migrationBuilder.DropSequence(
                name: "OfferId",
                schema: "common");

            migrationBuilder.DropSequence(
                name: "SupplierId",
                schema: "dict");
        }
    }
}
