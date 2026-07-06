using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacteSimchin_Web.Migrations
{
    /// <inheritdoc />
    public partial class AddAcceptNewPlayersColumnToGameSession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AcceptsNewPlayers",
                table: "GameSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptsNewPlayers",
                table: "GameSessions");
        }
    }
}
