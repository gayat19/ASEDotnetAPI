using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Invoices",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Username);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Username",
                table: "Invoices",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_Username",
                table: "Invoices",
                column: "Username",
                principalTable: "Users",
                principalColumn: "Username");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_Username",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_Username",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Invoices");
        }
    }
}
