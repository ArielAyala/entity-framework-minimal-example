using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entity_framework_minimal_example.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("1eac6be5-b1c3-459a-a325-058ab197a0fc"), null, "Personal activities", 50 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[] { new Guid("1eac6be5-b1c3-459a-a325-058ab197a0fd"), null, "Pending activities", 20 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "CreateDate", "Description", "TaskPriority", "Title" },
                values: new object[] { new Guid("508e3246-58ec-423a-b48d-30f9dcd94f9c"), new Guid("1eac6be5-b1c3-459a-a325-058ab197a0fd"), new DateTime(2022, 6, 22, 21, 7, 13, 178, DateTimeKind.Local).AddTicks(8298), null, 1, "Public services payment" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CategoryId", "CreateDate", "Description", "TaskPriority", "Title" },
                values: new object[] { new Guid("508e3246-58ec-423a-b48d-30f9dcd94f9d"), new Guid("1eac6be5-b1c3-459a-a325-058ab197a0fc"), new DateTime(2022, 6, 22, 21, 7, 13, 178, DateTimeKind.Local).AddTicks(8344), null, 0, "Check notes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("508e3246-58ec-423a-b48d-30f9dcd94f9c"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("508e3246-58ec-423a-b48d-30f9dcd94f9d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("1eac6be5-b1c3-459a-a325-058ab197a0fc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("1eac6be5-b1c3-459a-a325-058ab197a0fd"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }
    }
}
