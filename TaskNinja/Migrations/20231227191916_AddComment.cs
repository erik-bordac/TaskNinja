using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskNinja.Migrations
{
    /// <inheritdoc />
    public partial class AddComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TodoTaskID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comments_Tasks_TodoTaskID",
                        column: x => x.TodoTaskID,
                        principalTable: "Tasks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "CreatedDate", "TodoTaskID" },
                values: new object[,]
                {
                    { 1, "First comment on Task 1", new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5872), 24 },
                    { 2, "Another comment on Task 1", new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5880), 24 },
                    { 3, "Comment on Task 2", new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5882), 25 }
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5644), "Description for Task 1", new DateTime(2023, 12, 20, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5688), "High", "InProgress" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5697), "Description for Task 2", new DateTime(2024, 1, 10, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5700), "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5703), "Description for Task 3", new DateTime(2024, 1, 17, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5705), "Low", "Completed" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5708), "Description for Task 4", new DateTime(2023, 11, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5709), "High", "InProgress" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5712), "Description for Task 5", new DateTime(2024, 1, 6, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5713), "Medium", "Completed" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5719), "Description for Task 6", new DateTime(2023, 12, 25, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5720), "Low", "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5723), "Description for Task 7", new DateTime(2024, 1, 17, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5724), "InProgress" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5727), "Description for Task 8", new DateTime(2024, 1, 26, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5729), "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5731), "Description for Task 9", new DateTime(2024, 1, 3, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5738), "Description for Task 10", new DateTime(2024, 1, 10, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5739), "Medium", "InProgress" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TodoTaskID",
                table: "Comments",
                column: "TodoTaskID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 20, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(112), "Dummy task description 1", new DateTime(2024, 1, 4, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(167), "Low", "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 12, 22, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(176), "Dummy task description 2", new DateTime(2024, 1, 2, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(179), "InProgress" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 23, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(183), "Dummy task description 3", new DateTime(2023, 12, 24, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(185), "High", "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 18, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(188), "Dummy task description 4", new DateTime(2024, 1, 6, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(191), "Medium", "Completed" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 24, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(194), "Dummy task description 5", new DateTime(2023, 12, 30, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(196), "Low", "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 21, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(201), "Dummy task description 6", new DateTime(2024, 1, 1, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(204), "High", "InProgress" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 12, 19, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(207), "Dummy task description 7", new DateTime(2024, 1, 14, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(210), "NotStarted" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Status" },
                values: new object[] { new DateTime(2023, 12, 23, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(213), "Dummy task description 8", new DateTime(2024, 1, 3, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(215), "InProgress" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Description", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 17, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(218), "Dummy task description 9", new DateTime(2024, 1, 8, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(221) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Description", "DueDate", "Priority", "Status" },
                values: new object[] { new DateTime(2023, 12, 24, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(226), "Dummy task description 10", new DateTime(2023, 12, 30, 13, 14, 27, 690, DateTimeKind.Local).AddTicks(228), "High", "NotStarted" });
        }
    }
}
