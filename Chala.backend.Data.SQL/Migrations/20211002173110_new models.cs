using Microsoft.EntityFrameworkCore.Migrations;

namespace Chala.backend.Data.SQL.Migrations
{
    public partial class newmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TodoTasks");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "RegisterDate",
                table: "Users",
                newName: "CreateDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Routines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Routines");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Users",
                newName: "RegisterDate");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TodoTasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
