using DoctorAppointmentApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentApp.Contexts
{
    public class HospitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AS1KHLSL4P3T;TrustServerCertificate=True;Integrated Security=True;Database=dbHospitalManagement;");
        }

        //tables
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //seeding for Patient table
            modelBuilder.Entity<Patient>().HasData(
                 new Patient { Id = 1, Name = "John Doe", Gender = "Male", Age = 30, Mobile = "1234567890" },
                 new Patient { Id = 2, Name = "Jane Smith", Gender = "Female", Age = 25, Mobile = "9876543210" },
                 new Patient { Id = 3, Name = "Sam Wilson", Gender = "Male", Age = 40, Mobile = "5678901234" }
            );

            //seeding for Doctor table
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. John Watson", Gender = "Male", Specialization = "Cardiologist", Mobile = "9876543210", Availability = "Available" },
                new Doctor { Id = 2, Name = "Dr. Emily Clark", Gender = "Female", Specialization = "Dermatologist", Mobile = "1234567890", Availability = "Not Available" },
                new Doctor { Id = 3, Name = "Dr. Robert Brown", Gender = "Male", Specialization = "Orthopedic", Mobile = "5678901234", Availability = "Available" }
            );

            //Relational Mapping
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

           