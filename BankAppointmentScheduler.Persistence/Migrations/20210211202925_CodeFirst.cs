using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAppointmentScheduler.Persistence.Migrations
{
    public partial class CodeFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "t_users",
                newName: "t_users",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_services",
                newName: "t_services",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_schedules",
                newName: "t_schedules",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_counters",
                newName: "t_counters",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_counter_services",
                newName: "t_counter_services",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_branches",
                newName: "t_branches",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_banks",
                newName: "t_banks",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "t_appointments",
                newName: "t_appointments",
                newSchema: "public");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "t_users",
                schema: "public",
                newName: "t_users");

            migrationBuilder.RenameTable(
                name: "t_services",
                schema: "public",
                newName: "t_services");

            migrationBuilder.RenameTable(
                name: "t_schedules",
                schema: "public",
                newName: "t_schedules");

            migrationBuilder.RenameTable(
                name: "t_counters",
                schema: "public",
                newName: "t_counters");

            migrationBuilder.RenameTable(
                name: "t_counter_services",
                schema: "public",
                newName: "t_counter_services");

            migrationBuilder.RenameTable(
                name: "t_branches",
                schema: "public",
                newName: "t_branches");

            migrationBuilder.RenameTable(
                name: "t_banks",
                schema: "public",
                newName: "t_banks");

            migrationBuilder.RenameTable(
                name: "t_appointments",
                schema: "public",
                newName: "t_appointments");
        }
    }
}
