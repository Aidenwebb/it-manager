using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedInstitutionsToClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_institutions",
                table: "institutions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_clients",
                table: "institutions",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_clients",
                table: "institutions");

            migrationBuilder.AddPrimaryKey(
                name: "pk_institutions",
                table: "institutions",
                column: "id");
        }
    }
}
