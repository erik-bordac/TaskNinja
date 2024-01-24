using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskNinja.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Comments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "TEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "ID", "Content", "CreatedDate", "TodoTaskID" },
                values: new object[,]
                {
                    { 1, "First comment on Task 1", new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(6111), 24 },
                    { 2, "Another comment on Task 1", new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(6116), 24 },
                    { 3, "Comment on Task 2", new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(6118), 25 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "ID", "CreatedDate", "Description", "DueDate", "Name", "Priority", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5890), "Description for Task 1", new DateTime(2024, 1, 16, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5930), "Task 1", "High", "InProgress" },
                    { 2, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5939), "Description for Task 2", new DateTime(2024, 2, 6, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5940), "Task 2", "Medium", "NotStarted" },
                    { 3, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5943), "Description for Task 3", new DateTime(2024, 2, 13, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5944), "Task 3", "Low", "Completed" },
                    { 4, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5947), "Description for Task 4", new DateTime(2023, 12, 24, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5948), "Task 4", "High", "InProgress" },
                    { 5, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5950), "Description for Task 5", new DateTime(2024, 2, 2, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5951), "Task 5", "Medium", "Completed" },
                    { 6, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5955), "Description for Task 6", new DateTime(2024, 1, 21, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5956), "Task 6", "Low", "NotStarted" },
                    { 7, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5959), "Description for Task 7", new DateTime(2024, 2, 13, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5960), "Task 7", "Medium", "InProgress" },
                    { 8, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5962), "Description for Task 8", new DateTime(2024, 2, 22, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5964), "Task 8", "Low", "NotStarted" },
                    { 9, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5966), "Description for Task 9", new DateTime(2024, 1, 30, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5967), "Task 9", "High", "Completed" },
                    { 10, new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5970), "Description for Task 10", new DateTime(2024, 2, 6, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5972), "Task 10", "Medium", "InProgress" }
                });
        }
    }
}
