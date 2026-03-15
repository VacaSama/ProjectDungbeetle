using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDungbeetle.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCookiesEnabled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CookiesEnabled",
                table: "UserProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CookiesEnabled",
                table: "UserProfiles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
