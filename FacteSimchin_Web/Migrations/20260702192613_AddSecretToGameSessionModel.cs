using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacteSimchin_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddSecretToGameSessionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Secret",
                table: "GameSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Secret",
                table: "GameSessions");
        }
    }
}
