using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_Core_Intro.Migrations
{
    public partial class RenameProjectCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Employees_WorkersId1",
                table: "ProjectWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Projects_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorker_WorkersId1",
                table: "ProjectWorker");

            migrationBuilder.RenameColumn(
                name: "WorkersId1",
                table: "ProjectWorker",
                newName: "ProjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker",
                columns: new[] { "ProjectsId", "WorkersId" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Employees_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Projects_ProjectsId",
                table: "ProjectWorker",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Employees_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectWorker_Projects_ProjectsId",
                table: "ProjectWorker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker");

            migrationBuilder.DropIndex(
                name: "IX_ProjectWorker_WorkersId",
                table: "ProjectWorker");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectWorker",
                newName: "WorkersId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectWorker",
                table: "ProjectWorker",
                columns: new[] { "WorkersId", "WorkersId1" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectWorker_WorkersId1",
                table: "ProjectWorker",
                column: "WorkersId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Employees_WorkersId1",
                table: "ProjectWorker",
                column: "WorkersId1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectWorker_Projects_WorkersId",
                table: "ProjectWorker",
                column: "WorkersId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
