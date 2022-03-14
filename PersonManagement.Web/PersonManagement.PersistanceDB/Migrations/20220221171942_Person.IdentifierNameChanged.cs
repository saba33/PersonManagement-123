using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonManagement.PersistanceDB.Migrations
{
    public partial class PersonIdentifierNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonIdentifier",
                table: "Persons",
                newName: "Identifier");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_PersonIdentifier",
                table: "Persons",
                newName: "IX_Persons_Identifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identifier",
                table: "Persons",
                newName: "PersonIdentifier");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_Identifier",
                table: "Persons",
                newName: "IX_Persons_PersonIdentifier");
        }
    }
}
