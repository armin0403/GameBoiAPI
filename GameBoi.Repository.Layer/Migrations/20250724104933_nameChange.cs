using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBoi.Repository.Layer.Migrations
{
    /// <inheritdoc />
    public partial class nameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyGames_Prfiles_ProfileId",
                table: "MyGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Prfiles_Users_UserId",
                table: "Prfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prfiles",
                table: "Prfiles");

            migrationBuilder.RenameTable(
                name: "Prfiles",
                newName: "Profiles");

            migrationBuilder.RenameIndex(
                name: "IX_Prfiles_UserId",
                table: "Profiles",
                newName: "IX_Profiles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyGames_Profiles_ProfileId",
                table: "MyGames",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyGames_Profiles_ProfileId",
                table: "MyGames");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Prfiles");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserId",
                table: "Prfiles",
                newName: "IX_Prfiles_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prfiles",
                table: "Prfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MyGames_Prfiles_ProfileId",
                table: "MyGames",
                column: "ProfileId",
                principalTable: "Prfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prfiles_Users_UserId",
                table: "Prfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
