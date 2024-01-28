using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskNinja.Migrations
{
    /// <inheritdoc />
    public partial class AddTeamInvite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamInvites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SenderId = table.Column<string>(type: "TEXT", nullable: false),
                    RecipientId = table.Column<string>(type: "TEXT", nullable: false),
                    TeamId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamInvites_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamInvites_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamInvites_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RecipientId",
                table: "AspNetUsers",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SenderId",
                table: "AspNetUsers",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInvites_RecipientId",
                table: "TeamInvites",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInvites_SenderId",
                table: "TeamInvites",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamInvites_TeamId",
                table: "TeamInvites",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamInvites_RecipientId",
                table: "AspNetUsers",
                column: "RecipientId",
                principalTable: "TeamInvites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TeamInvites_SenderId",
                table: "AspNetUsers",
                column: "SenderId",
                principalTable: "TeamInvites",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamInvites_RecipientId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TeamInvites_SenderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TeamInvites");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RecipientId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SenderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "AspNetUsers");
        }
    }
}
