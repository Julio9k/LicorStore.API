using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiquorStore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddnewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Rolese_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rolese",
                table: "Rolese");

            migrationBuilder.RenameTable(
                name: "Rolese",
                newName: "Roles");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rolese");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rolese",
                table: "Rolese",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Rolese_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Rolese",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
