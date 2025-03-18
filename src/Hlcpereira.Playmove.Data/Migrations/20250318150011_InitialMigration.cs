using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hlcpereira.Playmove.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "fornecedor",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "varchar", nullable: true),
                    email = table.Column<string>(type: "varchar", nullable: true),
                    street = table.Column<string>(type: "varchar(100)", nullable: false),
                    number = table.Column<string>(type: "varchar(50)", nullable: true),
                    complement = table.Column<string>(type: "varchar(100)", nullable: true),
                    neighborhood = table.Column<string>(type: "varchar(100)", nullable: false),
                    zip_code = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedor", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fornecedor",
                schema: "public");
        }
    }
}
