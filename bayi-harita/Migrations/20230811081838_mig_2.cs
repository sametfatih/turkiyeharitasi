using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bayi_harita.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tel",
                table: "Bayiler",
                newName: "Tel3");

            migrationBuilder.AddColumn<string>(
                name: "Tel1",
                table: "Bayiler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tel2",
                table: "Bayiler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tel1",
                table: "Bayiler");

            migrationBuilder.DropColumn(
                name: "Tel2",
                table: "Bayiler");

            migrationBuilder.RenameColumn(
                name: "Tel3",
                table: "Bayiler",
                newName: "Tel");
        }
    }
}
