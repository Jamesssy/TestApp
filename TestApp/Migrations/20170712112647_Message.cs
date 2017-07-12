using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestApp.Migrations
{
    public partial class Message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meddelande",
                table: "Vegetables");

            migrationBuilder.AddColumn<int>(
                name: "MeddelandeId",
                table: "Vegetables",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Meddelande = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vegetables_MeddelandeId",
                table: "Vegetables",
                column: "MeddelandeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vegetables_Message_MeddelandeId",
                table: "Vegetables",
                column: "MeddelandeId",
                principalTable: "Message",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vegetables_Message_MeddelandeId",
                table: "Vegetables");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Vegetables_MeddelandeId",
                table: "Vegetables");

            migrationBuilder.DropColumn(
                name: "MeddelandeId",
                table: "Vegetables");

            migrationBuilder.AddColumn<string>(
                name: "Meddelande",
                table: "Vegetables",
                nullable: true);
        }
    }
}
