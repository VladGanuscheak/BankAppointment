using System.Threading;
using System.Threading.Tasks;
using BankAppointmentScheduler.Domain.BankEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankAppointmentScheduler.Domain
{
    public interface IBankAppointmentContext
    {
        public DbSet<Bank> Banks { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Counter> Counters { get; set; }

        public DbSet<CounterService> CounterServices { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<User> Users { get; set; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
