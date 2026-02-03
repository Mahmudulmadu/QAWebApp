using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q_A.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCleanSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 11, 8, 27, 636, DateTimeKind.Utc).AddTicks(7819));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 11, 8, 27, 636, DateTimeKind.Utc).AddTicks(7773));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1191));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1193));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1195));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1197));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1198));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 8, 27, 478, DateTimeKind.Utc).AddTicks(1236));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 3, 11, 8, 27, 636, DateTimeKind.Utc).AddTicks(7457), "$2a$11$bSu2tAITYb2WrWAmaBl79evWnlldrfuhXbt4P/xjdhpbzH5X/sk.K" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Answers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 2, 11, 1, 56, 123, DateTimeKind.Utc).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 1, 11, 1, 56, 123, DateTimeKind.Utc).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5938));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5941));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 2, 3, 11, 1, 55, 946, DateTimeKind.Utc).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 3, 11, 1, 56, 123, DateTimeKind.Utc).AddTicks(7057), "$2a$11$XxX2VmNTqQATnrn12neNa.KvwuyLQSHzxvzqsM7PxcWUq0Pxrbt.y" });
        }
    }
}
