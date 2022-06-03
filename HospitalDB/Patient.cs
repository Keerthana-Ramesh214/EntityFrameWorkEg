using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework_Eg.HospitalDB
{
    public partial class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
    }
}
