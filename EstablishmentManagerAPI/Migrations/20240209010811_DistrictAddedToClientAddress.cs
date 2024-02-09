using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstablishmentManagerAPI.Migrations
{
    /// <inheritdoc />
    public partial class DistrictAddedToClientAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Client_Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "District",
                table: "Client_Addresses");
        }
    }
}
