using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q_A.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedQuestionDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 4, 11, 30, 28, 952, DateTimeKind.Utc).AddTicks(6131));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 30, 28, 952, DateTimeKind.Utc).AddTicks(6001));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9002));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 30, 28, 796, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 5, 11, 30, 28, 952, DateTimeKind.Utc).AddTicks(5642), "$2a$11$Li2zRat9UxF02PaJqnL/CuhqPvI1gZg8lAi1HOqURvL16v4yCZUxe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 4, 11, 14, 32, 306, DateTimeKind.Utc).AddTicks(8248));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 14, 32, 306, DateTimeKind.Utc).AddTicks(8162));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8718));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8722));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 5, 11, 14, 32, 191, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 5, 11, 14, 32, 306, DateTimeKind.Utc).AddTicks(7634), "$2a$11$0D3cY776GcDJlRDAHfDFHuTiEVAsipTAyPG0GkaCafJ./R70GtLCK" });
        }
    }
}
