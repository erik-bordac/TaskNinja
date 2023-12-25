using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskNinja.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "CreatedDate", "Description", "DueDate", "Name", "Priority", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 20, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(112), "Dummy task description 1", new DateTime(2024, 1, 4, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(167), "Task 1", "Low", "NotStarted" },
                    { 2, new DateTime(2023, 12, 22, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(176), "Dummy task description 2", new DateTime(2024, 1, 2, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(179), "Task 2", "Medium", "InProgress" },
                    { 3, new DateTime(2023, 12, 23, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(183), "Dummy task description 3", new DateTime(2023, 12, 24, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(185), "Task 3", "High", "NotStarted" },
                    { 4, new DateTime(2023, 12, 18, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(188), "Dummy task description 4", new DateTime(2024, 1, 6, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(191), "Task 4", "Medium", "Completed" },
                    { 5, new DateTime(2023, 12, 24, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(194), "Dummy task description 5", new DateTime(2023, 12, 30, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(196), "Task 5", "Low", "NotStarted" },
                    { 6, new DateTime(2023, 12, 21, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(201), "Dummy task description 6", new DateTime(2024, 1, 1, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(204), "Task 6", "High", "InProgress" },
                    { 7, new DateTime(2023, 12, 19, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(207), "Dummy task description 7", new DateTime(2024, 1, 14, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(210), "Task 7", "Medium", "NotStarted" },
                    { 8, new DateTime(2023, 12, 23, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(213), "Dummy task description 8", new DateTime(2024, 1, 3, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(215), "Task 8", "Low", "InProgress" },
                    { 9, new DateTime(2023, 12, 17, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(218), "Dummy task description 9", new DateTime(2024, 1, 8, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(221), "Task 9", "High", "Completed" },
                    { 10, new DateTime(2023, 12, 24, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(226), "Dummy task description 10", new DateTime(2023, 12, 30, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(228), "Task 10", "High", "NotStarted" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
