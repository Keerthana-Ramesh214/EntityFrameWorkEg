using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework_Eg.HospitalDB
{
    public partial class AppointMent
    {
        public int AppointMentId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? DateOfAppoint { get; set; }
        public string Slot { get; set; }
        public int? PatientId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
