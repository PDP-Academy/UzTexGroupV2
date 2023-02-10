using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UzTexGroupV2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForLanguage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Languages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("3ce4f472-177c-4921-a605-185643577e34"), "en", "English" },
                    { new Guid("945986b4-cece-4bfa-b221-ca01e5c9118d"), "ru", "Russian" },
                    { new Guid("b6bbca81-6fb6-4485-9214-f650526d0d5b"), "uz", "Uzbek" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("3ce4f472-177c-4921-a605-185643577e34"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("945986b4-cece-4bfa-b221-ca01e5c9118d"));

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("b6bbca81-6fb6-4485-9214-f650526d0d5b"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Languages");
        }
    }
}
