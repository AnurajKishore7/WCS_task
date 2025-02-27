﻿using DoctorAppointmentApp.Entities;
using DoctorAppointmentApp.Contexts;
using DoctorAppointmentApp.Service;

namespace DoctorAppointmentApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new HospitalContext();
            var service = new HospitalService(context);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Hospital Management System ---");
                Console.WriteLine("1. Manage Patients");
                Console.WriteLine("2. Manage Doctors");
                Console.WriteLine("3. Manage Appointments");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ManagePatients(service);
                        break;
                    case "2":
                        ManageDoctors(service);
                        break;
                    case "3":
                        ManageAppointments(service);
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // Patient Management
        static void ManagePatients(HospitalService service)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- Patient Management ---");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. View Patient by ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Delete Patient");
                Console.WriteLine("6. Back");
                Console.Write("Choose an option: ");
                var patientChoice = Console.ReadLine();

                switch (patientChoice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        var patientName = Console.ReadLine();
                        Console.Write("Enter Gender: ");
                        var patientGender = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        var patientAge = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Mobile: ");
                        var patientMobile = Console.ReadLine();
                        service.AddPatient(new Patient { Name = patientName!, Gender = patientGender!, Age = patientAge, Mobile = patientMobile! });
                        Console.WriteLine("Patient added successfully.");
                        break;

                    case "2":
                        foreach (var p in service.GetAllPatients())
                            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Age: {p.Age}, Mobile: {p.Mobile}");
                        break;

                    case "3":
                        Console.Write("Enter Patient ID: ");
                        var patientId = int.Parse(Console.ReadLine()!);
                        var patientDetails = service.GetPatientById(patientId);
                        if (patientDetails != null)
                            Console.WriteLine($"ID: {patientDetails.Id}, Name: {patientDetails.Name}, Age: {patientDetails.Age}, Mobile: {patientDetails.Mobile}");
                        else
                            Console.WriteLine("Patient not found.");
                        break;

                    case "4":
                        Console.Write("Enter Patient ID to Update: ");
                        var updatePatientId = int.Parse(Console.ReadLine()!);
                        var patientToUpdate = service.GetPatientById(updatePatientId);
                        if (patientToUpdate != null)
                        {
                            Console.Write("Enter New Name: ");
                            patientToUpdate.Name = Console.ReadLine()!;
                            Console.Write("Enter New Gender: ");
                            patientToUpdate.Gender = Console.ReadLine()!;
                            Console.Write("Enter New Age: ");
                            patientToUpdate.Age = int.Parse(Console.ReadLine()!);
                            Console.Write("Enter New Mobile: ");
                            patientToUpdate.Mobile = Console.ReadLine()!;
                            service.UpdatePatient(patientToUpdate);
                            Console.WriteLine("Patient updated successfully.");
                        }
                        else
                            Console.WriteLine("Patient not found.");
                        break;

                    case "5":
                        Console.Write("Enter Patient ID to Delete: ");
                        service.DeletePatient(int.Parse(Console.ReadLine()!));
                        Console.WriteLine("Patient deleted successfully.");
                        break;

                    case "6":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // Doctor Management
        static void ManageDoctors(HospitalService service)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- Doctor Management ---");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. View Doctor by ID");
                Console.WriteLine("4. Update Doctor");
                Console.WriteLine("5. Delete Doctor");
                Console.WriteLine("6. Back");
                Console.Write("Choose an option: ");
                var doctorChoice = Console.ReadLine();

                switch (doctorChoice)
                {
                    case "1":
                        Console.Write("Enter Name: ");
                        var doctorName = Console.ReadLine();
                        Console.Write("Enter Gender: ");
                        var doctorGender = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        var doctorSpecialization = Console.ReadLine();
                        Console.Write("Enter Mobile: ");
                        var doctorMobile = Console.ReadLine();
                        Console.Write("Enter Availability: ");
                        var doctorAvailability = Console.ReadLine();
                        service.AddDoctor(new Doctor { Name = doctorName!, Gender = doctorGender!, Specialization = doctorSpecialization!, Mobile = doctorMobile!, Availability = doctorAvailability! });
                        Console.WriteLine("Doctor added successfully.");
                        break;

                    case "2":
                        foreach (var d in service.GetAllDoctors())
                            Console.WriteLine($"ID: {d.Id}, Name: {d.Name}, Specialization: {d.Specialization}, Mobile: {d.Mobile}");
                        break;

                    case "3":
                        Console.Write("Enter Doctor ID: ");
                        var doctorId = int.Parse(Console.ReadLine()!);
                        var doctorDetails = service.GetDoctorById(doctorId);
                        if (doctorDetails != null)
                            Console.WriteLine($"ID: {doctorDetails.Id}, Name: {doctorDetails.Name}, Specialization: {doctorDetails.Specialization}, Mobile: {doctorDetails.Mobile}");
                        else
                            Console.WriteLine("Doctor not found.");
                        break;

                    case "4":
                        Console.Write("Enter Doctor ID to Update: ");
                        var updateDoctorId = int.Parse(Console.ReadLine()!);
                        var doctorToUpdate = service.GetDoctorById(updateDoctorId);
                        if (doctorToUpdate != null)
                        {
                            Console.Write("Enter New Name: ");
                            doctorToUpdate.Name = Console.ReadLine()!;
                            Console.Write("Enter New Gender: ");
                            doctorToUpdate.Gender = Console.ReadLine()!;
                            Console.Write("Enter New Specialization: ");
                            doctorToUpdate.Specialization = Console.ReadLine()!;
                            Console.Write("Enter New Mobile: ");
                            doctorToUpdate.Mobile = Console.ReadLine()!;
                            Console.Write("Enter New Availability: ");
                            doctorToUpdate.Availability = Console.ReadLine()!;
                            service.UpdateDoctor(doctorToUpdate);
                            Console.WriteLine("Doctor updated successfully.");
                        }
                        else
                            Console.WriteLine("Doctor not found.");
                        break;

                    case "5":
                        Console.Write("Enter Doctor ID to Delete: ");
                        service.DeleteDoctor(int.Parse(Console.ReadLine()!));
                        Console.WriteLine("Doctor deleted successfully.");
                        break;

                    case "6":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // Appointment Management
        static void ManageAppointments(HospitalService service)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- Appointment Management ---");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. View All Appointments");
                Console.WriteLine("3. View Appointment by ID");
                Console.WriteLine("4. Delete Appointment");
                Console.WriteLine("5. Back");
                Console.Write("Choose an option: ");
                var appointmentChoice = Console.ReadLine();

                switch (appointmentChoice)
                {
                    case "1":
                        Console.Write("Enter Patient ID: ");
                        var appointmentPatientId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Doctor ID: ");
                        var appointmentDoctorId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Appointment Date (yyyy-MM-dd HH:mm): ");
                        var appointmentDate = DateTime.Parse(Console.ReadLine()!);
                        Console.Write("Enter Reason: ");
                        var appointmentReason = Console.ReadLine();
                        try
                        {
                            service.BookAppointment(appointmentPatientId, appointmentDoctorId, appointmentDate, appointmentReason!);
                            Console.WriteLine("Appointment booked successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "2":
                        foreach (var a in service.GetAllAppointments())
                            Console.WriteLine($"ID: {a.Id}, Patient: {a.Patient?.Name}, Doctor: {a.Doctor?.Name}, Date: {a.AppointmentDateTime}, Reason: {a.AppointmentReason}");
                        break;

                    case "3":
                        Console.Write("Enter Appointment ID: ");
                        var appointmentId = int.Parse(Console.ReadLine()!);
                        var appointmentDetails = service.GetAppointmentById(appointmentId);
                        if (appointmentDetails != null)
                            Console.WriteLine($"ID: {appointmentDetails.Id}, Patient: {appointmentDetails.Patient?.Name}, Doctor: {appointmentDetails.Doctor?.Name}, Date: {appointmentDetails.AppointmentDateTime}, Reason: {appointmentDetails.AppointmentReason}");
                        else
                            Console.WriteLine("Appointment not found.");
                        break;

                    case "4":
                        Console.Write("Enter Appointment ID to Delete: ");
                        service.DeleteAppointment(int.Parse(Console.ReadLine()!));
                        Console.WriteLine("Appointment deleted successfully.");
                        break;

                    case "5":
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
