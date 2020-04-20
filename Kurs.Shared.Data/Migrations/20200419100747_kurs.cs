using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kurs.Shared.Data.Migrations
{
    public partial class kurs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Exchangers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Exchangers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kurses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ExchangerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurses_Exchangers_ExchangerId",
                        column: x => x.ExchangerId,
                        principalTable: "Exchangers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kurses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exchangers_CityId",
                table: "Exchangers",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchangers_UserId",
                table: "Exchangers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurses_ExchangerId",
                table: "Kurses",
                column: "ExchangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Kurses_UserId",
                table: "Kurses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchangers_Cities_CityId",
                table: "Exchangers",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchangers_Users_UserId",
                table: "Exchangers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchangers_Cities_CityId",
                table: "Exchangers");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchangers_Users_UserId",
                table: "Exchangers");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Kurses");

            migrationBuilder.DropIndex(
                name: "IX_Exchangers_CityId",
                table: "Exchangers");

            migrationBuilder.DropIndex(
                name: "IX_Exchangers_UserId",
                table: "Exchangers");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Exchangers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Exchangers");
        }
    }
}
