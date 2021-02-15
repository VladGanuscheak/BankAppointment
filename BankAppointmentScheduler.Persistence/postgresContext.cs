using BankAppointmentScheduler.Configurations;
using BankAppointmentScheduler.Configurations.Configurations;
using BankAppointmentScheduler.Domain;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using BankAppointmentScheduler.Persistence.Views;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.Persistence
{
    public class postgresContext : DbContext, IBankAppointmentContext
    {
        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }


        public IBankAppointmentContext Instance => this;


        public DbSet<Bank> Banks { get; set; }
        
        public DbSet<Branch> Branches { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<Counter> Counters { get; set; }
       
        public DbSet<CounterService> CounterServices { get; set; }
        
        public DbSet<Schedule> Schedules { get; set; }
        
        public DbSet<Service> Services { get; set; }
        
        public DbSet<User> Users { get; set; }


        #region Views

        public virtual DbSet<appointment> appointments { get; set; }

        public virtual DbSet<bank> banks { get; set; }

        public virtual DbSet<branch> branches { get; set; }

        public virtual DbSet<counter> counters { get; set; }

        public virtual DbSet<counter_service> counter_services { get; set; }

        public virtual DbSet<schedule> schedules { get; set; }

        public virtual DbSet<service> services { get; set; }

        public virtual DbSet<user> users { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankConfig).Assembly);

            modelBuilder.HasPostgresExtension("adminpack")
                .HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            #region Relations

            modelBuilder.Entity<Bank>()
                .ToTable(EntityConstraints.BankConstraints.EntityName, "public");

            modelBuilder.Entity<Branch>()
                .ToTable(EntityConstraints.BranchConstraints.EntityName, "public");

            modelBuilder.Entity<Appointment>()
                .ToTable(EntityConstraints.AppointmentConstraints.EntityName, "public");

            modelBuilder.Entity<Counter>()
                .ToTable(EntityConstraints.CounterConstraints.EntityName, "public");

            modelBuilder.Entity<CounterService>()
                .ToTable(EntityConstraints.CounterServiceConstraints.EntityName, "public");

            modelBuilder.Entity<Schedule>()
                .ToTable(EntityConstraints.ScheduleConstraints.EntityName, "public");

            modelBuilder.Entity<Service>()
                .ToTable(EntityConstraints.ServiceConstraints.EntityName, "public");

            modelBuilder.Entity<User>()
                .ToTable(EntityConstraints.UserConstraints.EntityName, "public");

            #endregion

            #region Sequencies

            modelBuilder.HasSequence("bank_seq");

            modelBuilder.HasSequence("branch_seq");

            modelBuilder.HasSequence("counter_seq");

            modelBuilder.HasSequence("service_seq");

            #endregion


            base.OnModelCreating(modelBuilder);
        }
    }
}
