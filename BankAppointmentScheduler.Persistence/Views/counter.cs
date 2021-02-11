using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BankAppointmentScheduler.Persistence.Views
{
    [Keyless]
    public partial class counter
    {
        public int? counter_id { get; set; }
        public int? branch_id { get; set; }
        [StringLength(128)]
        public string bank_name { get; set; }
        public Guid? operator_id { get; set; }
        public int? counter_number { get; set; }
    }
}
