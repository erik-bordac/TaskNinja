using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskNinja.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(6111));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5890), new DateTime(2024, 1, 16, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5930) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5939), new DateTime(2024, 2, 6, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5940) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5943), new DateTime(2024, 2, 13, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5944) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5947), new DateTime(2023, 12, 24, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5948) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5950), new DateTime(2024, 2, 2, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5951) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5955), new DateTime(2024, 1, 21, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5956) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5959), new DateTime(2024, 2, 13, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5960) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5962), new DateTime(2024, 2, 22, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5964) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5966), new DateTime(2024, 1, 30, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5967) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2024, 1, 23, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5970), new DateTime(2024, 2, 6, 22, 27, 56, 185, DateTimeKind.Local).AddTicks(5972) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5882));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5644), new DateTime(2023, 12, 20, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5688) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5697), new DateTime(2024, 1, 10, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5703), new DateTime(2024, 1, 17, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5705) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5708), new DateTime(2023, 11, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5712), new DateTime(2024, 1, 6, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5713) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5719), new DateTime(2023, 12, 25, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5720) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5723), new DateTime(2024, 1, 17, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5724) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5727), new DateTime(2024, 1, 26, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5729) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5731), new DateTime(2024, 1, 3, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5733) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "CreatedDate", "DueDate" },
                values: new object[] { new DateTime(2023, 12, 27, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5738), new DateTime(2024, 1, 10, 20, 19, 16, 156, DateTimeKind.Local).AddTicks(5739) });
        }
    }
}
