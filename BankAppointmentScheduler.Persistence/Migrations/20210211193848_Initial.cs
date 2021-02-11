using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAppointmentScheduler.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:adminpack", ",,");

            migrationBuilder.CreateSequence(
                name: "bank_seq");

            migrationBuilder.CreateSequence(
                name: "branch_seq");

            migrationBuilder.CreateSequence(
                name: "counter_seq");

            migrationBuilder.CreateSequence(
                name: "service_seq");

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    branch_id = table.Column<int>(type: "integer", nullable: true),
                    service_id = table.Column<int>(type: "integer", nullable: true),
                    arrival_date = table.Column<DateTime>(type: "date", nullable: true),
                    arrival_time = table.Column<TimeSpan>(type: "time without time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    update_tmstmp = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "banks",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "integer", nullable: true),
                    bank_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    url = table.Column<string>(type: "character varying(526)", maxLength: 526, nullable: true),
                    total_branches = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "integer", nullable: true),
                    bank_id = table.Column<int>(type: "integer", nullable: true),
                    bank_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    total_counters = table.Column<long>(type: "bigint", nullable: true),
                    phone = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "counter_services",
                columns: table => new
                {
                    counter_id = table.Column<int>(type: "integer", nullable: true),
                    bank_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    branch_id = table.Column<int>(type: "integer", nullable: true),
                    counter_number = table.Column<int>(type: "integer", nullable: true),
                    service_id = table.Column<int>(type: "integer", nullable: true),
                    service_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "counters",
                columns: table => new
                {
                    counter_id = table.Column<int>(type: "integer", nullable: true),
                    branch_id = table.Column<int>(type: "integer", nullable: true),
                    bank_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    operator_id = table.Column<Guid>(type: "uuid", nullable: true),
                    counter_number = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "integer", nullable: true),
                    week_day = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    opening_time = table.Column<TimeSpan>(type: "time without time zone", nullable: true),
                    closing_time = table.Column<TimeSpan>(type: "time without time zone", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "integer", nullable: true),
                    service_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    total_specialized_branches = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "t_banks",
                columns: table => new
                {
                    bank_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('bank_seq'::regclass)"),
                    bank_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    url = table.Column<string>(type: "character varying(526)", maxLength: 526, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_banks_pkey", x => x.bank_id);
                });

            migrationBuilder.CreateTable(
                name: "t_services",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('service_seq'::regclass)"),
                    service_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_services_pkey", x => x.service_id);
                });

            migrationBuilder.CreateTable(
                name: "t_users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    first_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    last_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_users_pkey", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    first_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    last_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    total_appointments = table.Column<long>(type: "bigint", nullable: true),
                    is_operator = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "t_branches",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('branch_seq'::regclass)"),
                    bank_id = table.Column<int>(type: "integer", nullable: false),
                    phone = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_branches_pkey", x => new { x.branch_id, x.bank_id });
                    table.UniqueConstraint("AK_t_branches_branch_id", x => x.branch_id);
                    table.ForeignKey(
                        name: "t_branches_bank_id_fkey",
                        column: x => x.bank_id,
                        principalTable: "t_banks",
                        principalColumn: "bank_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_appointments",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    branch_id = table.Column<int>(type: "integer", nullable: false),
                    service_id = table.Column<int>(type: "integer", nullable: false),
                    arrival_date = table.Column<DateTime>(type: "date", nullable: false),
                    arrival_time = table.Column<TimeSpan>(type: "time without time zone", nullable: true),
                    status = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    update_tmstmp = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_appointments_pkey", x => new { x.user_id, x.branch_id, x.service_id });
                    table.ForeignKey(
                        name: "t_appointments_branch_id_fkey",
                        column: x => x.branch_id,
                        principalTable: "t_branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "t_appointments_service_id_fkey",
                        column: x => x.service_id,
                        principalTable: "t_services",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "t_appointments_user_id_fkey",
                        column: x => x.user_id,
                        principalTable: "t_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_counters",
                columns: table => new
                {
                    counter_id = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "nextval('counter_seq'::regclass)"),
                    branch_id = table.Column<int>(type: "integer", nullable: true),
                    operator_id = table.Column<Guid>(type: "uuid", nullable: true),
                    counter_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_counters_pkey", x => x.counter_id);
                    table.ForeignKey(
                        name: "t_counters_branch_id_fkey",
                        column: x => x.branch_id,
                        principalTable: "t_branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "t_counters_operator_id_fkey",
                        column: x => x.operator_id,
                        principalTable: "t_users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_schedules",
                columns: table => new
                {
                    branch_id = table.Column<int>(type: "integer", nullable: false),
                    week_day = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    opening_time = table.Column<TimeSpan>(type: "time without time zone", nullable: false),
                    closing_time = table.Column<TimeSpan>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_schedules_pkey", x => new { x.branch_id, x.week_day });
                    table.ForeignKey(
                        name: "t_schedules_branch_id_fkey",
                        column: x => x.branch_id,
                        principalTable: "t_branches",
                        principalColumn: "branch_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "t_counter_services",
                columns: table => new
                {
                    counter_id = table.Column<int>(type: "integer", nullable: false),
                    service_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("t_counter_services_pkey", x => new { x.counter_id, x.service_id });
                    table.ForeignKey(
                        name: "t_counter_services_counter_id_fkey",
                        column: x => x.counter_id,
                        principalTable: "t_counters",
                        principalColumn: "counter_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "t_counter_services_service_id_fkey",
                        column: x => x.service_id,
                        principalTable: "t_services",
                        principalColumn: "service_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_appointments_branch_id",
                table: "t_appointments",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_appointments_service_id",
                table: "t_appointments",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_branches_bank_id",
                table: "t_branches",
                column: "bank_id");

            migrationBuilder.CreateIndex(
                name: "t_branches_branch_id_key",
                table: "t_branches",
                column: "branch_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_t_counter_services_service_id",
                table: "t_counter_services",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_counters_branch_id",
                table: "t_counters",
                column: "branch_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_counters_operator_id",
                table: "t_counters",
                column: "operator_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "banks");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "counter_services");

            migrationBuilder.DropTable(
                name: "counters");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "t_appointments");

            migrationBuilder.DropTable(
                name: "t_counter_services");

            migrationBuilder.DropTable(
                name: "t_schedules");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "t_counters");

            migrationBuilder.DropTable(
                name: "t_services");

            migrationBuilder.DropTable(
                name: "t_branches");

            migrationBuilder.DropTable(
                name: "t_users");

            migrationBuilder.DropTable(
                name: "t_banks");

            migrationBuilder.DropSequence(
                name: "bank_seq");

            migrationBuilder.DropSequence(
                name: "branch_seq");

            migrationBuilder.DropSequence(
                name: "counter_seq");

            migrationBuilder.DropSequence(
                name: "service_seq");
        }
    }
}
