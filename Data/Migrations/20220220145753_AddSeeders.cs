using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core_Intro.Migrations
{
    public partial class AddSeeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Ukraine" },
                    { 2, "Poland" },
                    { 3, "Italy" },
                    { 4, "Spain" }
                });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Number",
                keyValue: 1,
                columns: new[] { "Name", "Phone" },
                values: new object[] { "Security Programming", "3455-223-44" });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Number",
                keyValue: 2,
                columns: new[] { "Name", "Phone" },
                values: new object[] { "Design", "45462-223-44" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Number", "Name", "Phone" },
                values: new object[] { 3, "Admin Department", "101010-44-44" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Helps people to sort the rubbish.", "Eco Project in Rivne" },
                    { 2, "Helps people to find animals.", "Vets-Pets" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Number",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Number",
                keyValue: 1,
                columns: new[] { "Name", "Phone" },
                values: new object[] { "Design", null });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Number",
                keyValue: 2,
                columns: new[] { "Name", "Phone" },
                values: new object[] { "Programming", "45-34-23" });
        }
    }
}
