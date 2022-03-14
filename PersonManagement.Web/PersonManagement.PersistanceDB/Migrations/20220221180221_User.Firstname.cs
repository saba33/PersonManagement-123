using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonManagement.PersistanceDB.Migrations
{
    public partial class UserFirstname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "FirstNam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstNam",
                table: "Users",
                newName: "FirstName");
        }
    }
}
