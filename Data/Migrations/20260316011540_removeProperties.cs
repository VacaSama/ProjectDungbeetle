using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDungbeetle.Migrations
{
    /// <inheritdoc />
    public partial class removeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntendedUse",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "LearningLanguages",
                table: "UserProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IntendedUse",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LearningLanguages",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
