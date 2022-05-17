using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Infrastructure.Persistance.Migrations;

public partial class init : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "EmailConfirmations",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                OldEmail = table.Column<string>(type: "text", nullable: true),
                NewEmail = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EmailConfirmations", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Nickname = table.Column<string>(type: "text", nullable: true),
                Email = table.Column<string>(type: "text", nullable: true),
                Pass = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Entries",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                Subject = table.Column<string>(type: "text", nullable: true),
                Content = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Entries", x => x.Id);
                table.ForeignKey(
                    name: "FK_Entries_Users_CreatedById",
                    column: x => x.CreatedById,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EntryComments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EntryId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                Content = table.Column<string>(type: "text", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EntryComments", x => x.Id);
                table.ForeignKey(
                    name: "FK_EntryComments_Entries_EntryId",
                    column: x => x.EntryId,
                    principalTable: "Entries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EntryComments_Users_CreatedById",
                    column: x => x.CreatedById,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "EntryClaps",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EntryId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                Clap = table.Column<int>(type: "integer", nullable: false),
                EntryCommentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EntryClaps", x => x.Id);
                table.ForeignKey(
                    name: "FK_EntryClaps_Entries_EntryId",
                    column: x => x.EntryId,
                    principalTable: "Entries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EntryClaps_EntryComments_EntryCommentId",
                    column: x => x.EntryCommentId,
                    principalTable: "EntryComments",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "EntryStars",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                EntryId = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                CreatedUserId = table.Column<Guid>(type: "uuid", nullable: true),
                EntryCommentId = table.Column<Guid>(type: "uuid", nullable: true),
                CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                Status = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EntryStars", x => x.Id);
                table.ForeignKey(
                    name: "FK_EntryStars_Entries_EntryId",
                    column: x => x.EntryId,
                    principalTable: "Entries",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_EntryStars_EntryComments_EntryCommentId",
                    column: x => x.EntryCommentId,
                    principalTable: "EntryComments",
                    principalColumn: "Id");
                table.ForeignKey(
                    name: "FK_EntryStars_Users_CreatedUserId",
                    column: x => x.CreatedUserId,
                    principalTable: "Users",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateIndex(
            name: "IX_Entries_CreatedById",
            table: "Entries",
            column: "CreatedById");

        migrationBuilder.CreateIndex(
            name: "IX_EntryClaps_EntryCommentId",
            table: "EntryClaps",
            column: "EntryCommentId");

        migrationBuilder.CreateIndex(
            name: "IX_EntryClaps_EntryId",
            table: "EntryClaps",
            column: "EntryId");

        migrationBuilder.CreateIndex(
            name: "IX_EntryComments_CreatedById",
            table: "EntryComments",
            column: "CreatedById");

        migrationBuilder.CreateIndex(
            name: "IX_EntryComments_EntryId",
            table: "EntryComments",
            column: "EntryId");

        migrationBuilder.CreateIndex(
            name: "IX_EntryStars_CreatedUserId",
            table: "EntryStars",
            column: "CreatedUserId");

        migrationBuilder.CreateIndex(
            name: "IX_EntryStars_EntryCommentId",
            table: "EntryStars",
            column: "EntryCommentId");

        migrationBuilder.CreateIndex(
            name: "IX_EntryStars_EntryId",
            table: "EntryStars",
            column: "EntryId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "EmailConfirmations");

        migrationBuilder.DropTable(
            name: "EntryClaps");

        migrationBuilder.DropTable(
            name: "EntryStars");

        migrationBuilder.DropTable(
            name: "EntryComments");

        migrationBuilder.DropTable(
            name: "Entries");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
