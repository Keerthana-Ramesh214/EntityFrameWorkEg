using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework_Eg.HospitalDB
{
    public partial class Doctor
    {
        public Doctor()
        {
            AppointMents = new HashSet<AppointMent>();
        }

        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Specialization { get; set; }
        public string VisitingHours { get; set; }

        public virtual ICollection<AppointMent> AppointMents { get; set; }
    }
}
