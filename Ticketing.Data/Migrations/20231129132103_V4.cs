using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.Data.Migrations
{
    /// <inheritdoc />
    public partial class V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SectionId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SectionId",
                table: "Tickets",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Sections_SectionId",
                table: "Tickets",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Sections_SectionId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SectionId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SectionId",
                table: "Tickets");
        }
    }
}
