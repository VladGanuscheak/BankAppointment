using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class schedule
    {
        public int? branch_id { get; set; }
        [StringLength(16)]
        public string week_day { get; set; }
        [Column(TypeName = "time without time zone")]
        public TimeSpan? opening_time { get; set; }
        [Column(TypeName = "time without time zone")]
        public TimeSpan? closing_time { get; set; }
    }
}
