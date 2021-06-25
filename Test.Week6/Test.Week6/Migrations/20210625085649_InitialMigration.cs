using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Week6.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    CF = table.Column<string>(type: "nchar(16)", fixedLength: true, maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.CF);
                });

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Instalment = table.Column<float>(type: "real", nullable: false),
                    ClientCF = table.Column<string>(type: "nchar(16)", nullable: true),
                    KindofPolicy = table.Column<string>(name: "Kind of Policy", type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Coverage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Number);
                    table.ForeignKey(
                        name: "FK_Policy_Client_ClientCF",
                        column: x => x.ClientCF,
                        principalTable: "Client",
                        principalColumn: "CF",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Policy_ClientCF",
                table: "Policy",
                column: "ClientCF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
