using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class user
    {
        public Guid? user_id { get; set; }
        [StringLength(128)]
        public string email { get; set; }
        [StringLength(128)]
        public string first_name { get; set; }
        [StringLength(128)]
        public string last_name { get; set; }
        public long? total_appointments { get; set; }
        public bool? is_operator { get; set; }
    }
}
