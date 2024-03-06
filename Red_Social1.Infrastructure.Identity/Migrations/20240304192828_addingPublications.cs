using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Red_Social1.Infrastructure.Identity.Migrations
{
    /// <inheritdoc />
    public partial class addingPublications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publication_Users_ApplicationUserId",
                schema: "Identity",
                table: "Publication");

            migrationBuilder.DropIndex(
                name: "IX_Publication_ApplicationUserId",
                schema: "Identity",
                table: "Publication");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Publication");

            migrationBuilder.AddColumn<int>(
                name: "PublicationUserId",
                schema: "Identity",
                table: "Comentary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publications",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComentaryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentary_PublicationUserId",
                schema: "Identity",
                table: "Comentary",
                column: "PublicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_UserId",
                schema: "Identity",
                table: "Publications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentary_Publications_PublicationUserId",
                schema: "Identity",
                table: "Comentary",
                column: "PublicationUserId",
                principalSchema: "Identity",
                principalTable: "Publications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentary_Publications_PublicationUserId",
                schema: "Identity",
                table: "Comentary");

            migrationBuilder.DropTable(
                name: "Publications",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Comentary_PublicationUserId",
                schema: "Identity",
                table: "Comentary");

            migrationBuilder.DropColumn(
                name: "PublicationUserId",
                schema: "Identity",
                table: "Comentary");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                schema: "Identity",
                table: "Publication",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Publication_ApplicationUserId",
                schema: "Identity",
                table: "Publication",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publication_Users_ApplicationUserId",
                schema: "Identity",
                table: "Publication",
                column: "ApplicationUserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
