using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_framework_minimal_example.Migrations
{
    public partial class ColumnWeightInCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Categories");
        }
    }
}
