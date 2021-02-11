using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.Configurations
{
    public static class EntityConstraints
    {
        public static class BankConstraints
        {
            public const string EntityName = "t_banks";

            public static class KeyConstraints
            {
                public const string DefaultValueSql = "nextval('bank_seq'::regclass)";

                public const string PropertyName = "bank_id";

                public const string Name = "t_banks_pkey";
            }

            public static class NameConstraints
            {
                public const int Length = 128;

                public const bool IsRequired = true;

                public const string Name = "bank_name";
            }

            public static class UrlConstraints
            {
                public const int Length = 526;

                public const bool IsRequired = true;

                public const string Name = "url";
            }
        }

        public static class BranchConstraints
        {
            public const string EntityName = "t_branches";

            public static class KeyConstraints
            {
                public const string PropertyName = "branch_id";


                public const string DefaultValueSql = "nextval('branch_seq'::regclass)";


                public const string IndexName = "t_branches_branch_id_key";


                public const string Name = "t_branches_pkey";
            }

            public static class BankIdConstraints
            {
                public const string PropertyName = "bank_id";
            }

            public static class PhoneConstraints
            {
                public const int Length = 128;

                public const bool IsRequired = true;

                public const string Name = "phone";
            }

            public static class AddressConstraints
            {
                public const int Length = 256;

                public const bool IsRequired = true;

                public const string Name = "address";
            }

            public static class BankForeignKeyConstraint
            {
                public const string Name = "t_branches_bank_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }
        }

        public static class ScheduleConstraints
        {
            public const string EntityName = "t_schedules";

            public static class KeyConstraints
            {
                public static class BranchId
                {
                    public const string PropertyName = "branch_id";
                }

                public static class WeekDay
                {
                    public const string PropertyName = "week_day";

                    public const int Length = 16;
                }

                public const string Name = "t_schedules_pkey";
            }

            public static class OpeningTime
            {
                public const string Name = "opening_time";

                public const string ColumnTypeName = "time without time zone";
            }

            public static class ClosingTime
            {
                public const string Name = "closing_time";

                public const string ColumnTypeName = "time without time zone";
            }

            public static class BranchForeignKeyConstraint
            {
                public const string Name = "t_schedules_branch_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }
        }

        public static class CounterConstraints
        {
            public const string EntityName = "t_counters";

            public static class KeyConstraints
            {
                public const string PropertyName = "counter_id";

                public const string Name = "t_counters_pkey";

                public const string DefaultValueSql = "nextval('counter_seq'::regclass)";
            }

            public static class BranchIdConstraints
            {
                public const string Name = "branch_id";
            }

            public static class OperatorIdConstraints
            {
                public const string Name = "operator_id";
            }

            public static class CounterNumberConstraints
            {
                public const string Name = "counter_number";
            }

            public static class BranchForeignKeyConstraint
            {
                public const string ConstraintName = "t_counters_branch_id_fkey";
            }

            public static class OperatorForeignKeyConstraint
            {
                public const string ConstraintName = "t_counters_operator_id_fkey";
            }
        }

        public static class CounterServiceConstraints
        {
            public const string EntityName = "t_counter_services";

            public static class KeyConstraints
            {
                public static class CounterIdConstraints
                {
                    public const string Name = "counter_id";
                }

                public static class ServiceIdConstraints
                {
                    public const string Name = "service_id";
                }

                public const string Name = "t_counter_services_pkey";
            }

            public static class CounterForeignKeyConstraints
            {
                public const string ConstraintName = "t_counter_services_counter_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }

            public static class ServiceForeignKeyConstraints
            {
                public const string ConstraintName = "t_counter_services_service_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }
        }

        public static class UserConstraints
        {
            public const string EntityName = "t_users";

            public static class KeyConstraints
            {
                public const string PropertyName = "user_id";

                public const string Name = "t_users_pkey";

                public const string DefaultValueSql = "gen_random_uuid()";
            }

            public static class EmailConstraints
            {
                public const int Length = 128;

                public const bool IsRequired = true;

                public const string Name = "email";
            }

            public static class FirstNameConstraints
            {
                public const int Length = 128;

                public const bool IsRequired = true;

                public const string Name = "first_name";
            }

            public static class LastNameConstraints
            {
                public const int Length = 128;

                public const bool IsRequired = true;

                public const string Name = "last_name";
            }
        }

        public static class ServiceConstraints
        {
            public const string EntityName = "t_services";

            public static class KeyConstraints
            {
                public const string PropertyName = "service_id";

                public const string Name = "t_services_pkey";

                public const string DefaultValueSql = "nextval('service_seq'::regclass)";
            }

            public static class ServiceNameConstraints
            {
                public const int Length = 128;

                public const bool IsRequired = true;

                public const string Name = "service_name";
            }
        }

        public static class AppointmentConstraints
        {
            public const string EntityName = "t_appointments";

            public static class KeyConstraints
            {
                public const string Name = "t_appointments_pkey";

                public static class UserIdConstraints
                {
                    public const string PropertyName = "user_id";
                }

                public static class BranchIdConstraints
                {
                    public const string PropertyName = "branch_id";
                }

                public static class ServiceIdConstraints
                {
                    public const string PropertyName = "service_id";
                }
            }

            public static class ArrivalDateConstraints
            {
                public const string Name = "arrival_date";

                public const string ColumnTypeName = "date";
            }

            public static class ArrivalTimeConstraints
            {
                public const string Name = "arrival_time";

                public const string ColumnTypeName = "time without time zone";
            }

            public static class StatusConstraints
            {
                public const int Length = 64;

                public const string Name = "status";
            }

            public static class UpdateTimeStampConstraints
            {
                public const string Name = "update_tmstmp";
            }

            public static class BranchForeignKeyConstraint
            {
                public const string ConstraintName = "t_appointments_branch_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }

            public static class ServiceForeignKeyConstraint
            {
                public const string ConstraintName = "t_appointments_service_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }

            public static class UserForeignKeyConstraint
            {
                public const string ConstraintName = "t_appointments_user_id_fkey";

                public const DeleteBehavior Behavior = DeleteBehavior.ClientSetNull;
            }
        }
    }
}
