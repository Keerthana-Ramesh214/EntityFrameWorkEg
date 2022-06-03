using System;
using EntityFramework_Eg.HospitalDB;

namespace EntityFramework_Eg
{
    class Program
    {
        static void Main(string[] args)
        {
            Hospital_DbContext db = new Hospital_DbContext();
            foreach(var item in db.Doctors)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Doctor_Id:" + item.DoctorId);
                Console.WriteLine("Doctor_Name:" + item.FirstName +" "+ item.LastName);
                Console.WriteLine("Gender:" + item.Sex);
                Console.WriteLine("Specialization:" + item.Specialization);
                Console.WriteLine("Visiting_Hours:" + item.VisitingHours);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("**********************************************************");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
