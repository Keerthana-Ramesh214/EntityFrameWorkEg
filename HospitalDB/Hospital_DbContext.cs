using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFramework_Eg.HospitalDB
{
    public partial class Hospital_DbContext : DbContext
    {
        public Hospital_DbContext()
        {
        }

        public Hospital_DbContext(DbContextOptions<Hospital_DbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointMent> AppointMents { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<UserPass> UserPasses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Hospital_Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppointMent>(entity =>
            {
                entity.ToTable("AppointMent");

                entity.Property(e => e.AppointMentId).HasColumnName("AppointMent_Id");

                entity.Property(e => e.DateOfAppoint).HasColumnType("date");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.Slot)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.AppointMents)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__AppointMe__Docto__571DF1D5");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("Doctor");

                entity.Property(e => e.DoctorId).HasColumnName("Doctor_Id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Specialization)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VisitingHours)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Visiting_Hours");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserPass");

                entity.Property(e => e.Password1)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
