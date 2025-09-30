using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace code_first_app.Migrations
{
    /// <inheritdoc />
    public partial class ChangeManagerIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
        name: "FK_Employees_Employees_ManagerId",
        table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "ManagerId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
