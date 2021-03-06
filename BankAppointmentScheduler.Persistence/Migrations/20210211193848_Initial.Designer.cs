﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BankAppointmentScheduler.Persistence.Migrations
{
    [DbContext(typeof(postgresContext))]
    [Migration("20210211193848_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.HasSequence("bank_seq");

            modelBuilder.HasSequence("branch_seq");

            modelBuilder.HasSequence("counter_seq");

            modelBuilder.HasSequence("service_seq");

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.appointment", b =>
                {
                    b.Property<DateTime?>("arrival_date")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("arrival_time")
                        .HasColumnType("time without time zone");

                    b.Property<int?>("branch_id")
                        .HasColumnType("integer");

                    b.Property<int?>("service_id")
                        .HasColumnType("integer");

                    b.Property<string>("status")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("update_tmstmp")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("user_id")
                        .HasColumnType("uuid");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.bank", b =>
                {
                    b.Property<int?>("bank_id")
                        .HasColumnType("integer");

                    b.Property<string>("bank_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long?>("total_branches")
                        .HasColumnType("bigint");

                    b.Property<string>("url")
                        .HasMaxLength(526)
                        .HasColumnType("character varying(526)");

                    b.ToTable("banks");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.branch", b =>
                {
                    b.Property<string>("address")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int?>("bank_id")
                        .HasColumnType("integer");

                    b.Property<string>("bank_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int?>("branch_id")
                        .HasColumnType("integer");

                    b.Property<string>("phone")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long?>("total_counters")
                        .HasColumnType("bigint");

                    b.ToTable("branches");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.counter", b =>
                {
                    b.Property<string>("bank_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int?>("branch_id")
                        .HasColumnType("integer");

                    b.Property<int?>("counter_id")
                        .HasColumnType("integer");

                    b.Property<int?>("counter_number")
                        .HasColumnType("integer");

                    b.Property<Guid?>("operator_id")
                        .HasColumnType("uuid");

                    b.ToTable("counters");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.counter_service", b =>
                {
                    b.Property<string>("bank_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<int?>("branch_id")
                        .HasColumnType("integer");

                    b.Property<int?>("counter_id")
                        .HasColumnType("integer");

                    b.Property<int?>("counter_number")
                        .HasColumnType("integer");

                    b.Property<int?>("service_id")
                        .HasColumnType("integer");

                    b.Property<string>("service_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.ToTable("counter_services");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.schedule", b =>
                {
                    b.Property<int?>("branch_id")
                        .HasColumnType("integer");

                    b.Property<TimeSpan?>("closing_time")
                        .HasColumnType("time without time zone");

                    b.Property<TimeSpan?>("opening_time")
                        .HasColumnType("time without time zone");

                    b.Property<string>("week_day")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.service", b =>
                {
                    b.Property<int?>("service_id")
                        .HasColumnType("integer");

                    b.Property<string>("service_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long?>("total_specialized_branches")
                        .HasColumnType("bigint");

                    b.ToTable("services");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_appointment", b =>
                {
                    b.Property<Guid>("user_id")
                        .HasColumnType("uuid");

                    b.Property<int>("branch_id")
                        .HasColumnType("integer");

                    b.Property<int>("service_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("arrival_date")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("arrival_time")
                        .HasColumnType("time without time zone");

                    b.Property<string>("status")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime?>("update_tmstmp")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("user_id", "branch_id", "service_id")
                        .HasName("t_appointments_pkey");

                    b.HasIndex("branch_id");

                    b.HasIndex("service_id");

                    b.ToTable("t_appointments");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_bank", b =>
                {
                    b.Property<int>("bank_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('bank_seq'::regclass)");

                    b.Property<string>("bank_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("url")
                        .IsRequired()
                        .HasMaxLength(526)
                        .HasColumnType("character varying(526)");

                    b.HasKey("bank_id")
                        .HasName("t_banks_pkey");

                    b.ToTable("t_banks");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_branch", b =>
                {
                    b.Property<int>("branch_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('branch_seq'::regclass)");

                    b.Property<int>("bank_id")
                        .HasColumnType("integer");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("branch_id", "bank_id")
                        .HasName("t_branches_pkey");

                    b.HasIndex("bank_id");

                    b.HasIndex(new[] { "branch_id" }, "t_branches_branch_id_key")
                        .IsUnique();

                    b.ToTable("t_branches");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_counter", b =>
                {
                    b.Property<int>("counter_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('counter_seq'::regclass)");

                    b.Property<int?>("branch_id")
                        .HasColumnType("integer");

                    b.Property<int>("counter_number")
                        .HasColumnType("integer");

                    b.Property<Guid?>("operator_id")
                        .HasColumnType("uuid");

                    b.HasKey("counter_id")
                        .HasName("t_counters_pkey");

                    b.HasIndex("branch_id");

                    b.HasIndex("operator_id");

                    b.ToTable("t_counters");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_counter_service", b =>
                {
                    b.Property<int>("counter_id")
                        .HasColumnType("integer");

                    b.Property<int>("service_id")
                        .HasColumnType("integer");

                    b.HasKey("counter_id", "service_id")
                        .HasName("t_counter_services_pkey");

                    b.HasIndex("service_id");

                    b.ToTable("t_counter_services");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_schedule", b =>
                {
                    b.Property<int>("branch_id")
                        .HasColumnType("integer");

                    b.Property<string>("week_day")
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<TimeSpan>("closing_time")
                        .HasColumnType("time without time zone");

                    b.Property<TimeSpan>("opening_time")
                        .HasColumnType("time without time zone");

                    b.HasKey("branch_id", "week_day")
                        .HasName("t_schedules_pkey");

                    b.ToTable("t_schedules");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_service", b =>
                {
                    b.Property<int>("service_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('service_seq'::regclass)");

                    b.Property<string>("service_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("service_id")
                        .HasName("t_services_pkey");

                    b.ToTable("t_services");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_user", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("user_id")
                        .HasName("t_users_pkey");

                    b.ToTable("t_users");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.user", b =>
                {
                    b.Property<string>("email")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("first_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<bool?>("is_operator")
                        .HasColumnType("boolean");

                    b.Property<string>("last_name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long?>("total_appointments")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("user_id")
                        .HasColumnType("uuid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_appointment", b =>
                {
                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_branch", "branch")
                        .WithMany("t_appointments")
                        .HasForeignKey("branch_id")
                        .HasConstraintName("t_appointments_branch_id_fkey")
                        .HasPrincipalKey("branch_id")
                        .IsRequired();

                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_service", "service")
                        .WithMany("t_appointments")
                        .HasForeignKey("service_id")
                        .HasConstraintName("t_appointments_service_id_fkey")
                        .IsRequired();

                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_user", "user")
                        .WithMany("t_appointments")
                        .HasForeignKey("user_id")
                        .HasConstraintName("t_appointments_user_id_fkey")
                        .IsRequired();

                    b.Navigation("branch");

                    b.Navigation("service");

                    b.Navigation("user");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_branch", b =>
                {
                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_bank", "bank")
                        .WithMany("t_branches")
                        .HasForeignKey("bank_id")
                        .HasConstraintName("t_branches_bank_id_fkey")
                        .IsRequired();

                    b.Navigation("bank");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_counter", b =>
                {
                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_branch", "branch")
                        .WithMany("t_counters")
                        .HasForeignKey("branch_id")
                        .HasConstraintName("t_counters_branch_id_fkey")
                        .HasPrincipalKey("branch_id");

                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_user", "_operator")
                        .WithMany("t_counters")
                        .HasForeignKey("operator_id")
                        .HasConstraintName("t_counters_operator_id_fkey");

                    b.Navigation("_operator");

                    b.Navigation("branch");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_counter_service", b =>
                {
                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_counter", "counter")
                        .WithMany("t_counter_services")
                        .HasForeignKey("counter_id")
                        .HasConstraintName("t_counter_services_counter_id_fkey")
                        .IsRequired();

                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_service", "service")
                        .WithMany("t_counter_services")
                        .HasForeignKey("service_id")
                        .HasConstraintName("t_counter_services_service_id_fkey")
                        .IsRequired();

                    b.Navigation("counter");

                    b.Navigation("service");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_schedule", b =>
                {
                    b.HasOne("BankAppointmentScheduler.Persistence.Models.t_branch", "branch")
                        .WithMany("t_schedules")
                        .HasForeignKey("branch_id")
                        .HasConstraintName("t_schedules_branch_id_fkey")
                        .HasPrincipalKey("branch_id")
                        .IsRequired();

                    b.Navigation("branch");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_bank", b =>
                {
                    b.Navigation("t_branches");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_branch", b =>
                {
                    b.Navigation("t_appointments");

                    b.Navigation("t_counters");

                    b.Navigation("t_schedules");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_counter", b =>
                {
                    b.Navigation("t_counter_services");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_service", b =>
                {
                    b.Navigation("t_appointments");

                    b.Navigation("t_counter_services");
                });

            modelBuilder.Entity("BankAppointmentScheduler.Persistence.Models.t_user", b =>
                {
                    b.Navigation("t_appointments");

                    b.Navigation("t_counters");
                });
#pragma warning restore 612, 618
        }
    }
}
