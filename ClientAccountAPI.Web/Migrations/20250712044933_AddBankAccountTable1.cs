using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientAccountAPI.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddBankAccountTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idCard",
                table: "Customers",
                newName: "CardIdentificacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardIdentificacion",
                table: "Customers",
                newName: "idCard");
        }
    }
}
