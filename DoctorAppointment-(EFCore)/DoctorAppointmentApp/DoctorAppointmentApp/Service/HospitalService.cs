﻿using DoctorAppointmentApp.Contexts;
using DoctorAppointmentApp.Entities;
using DoctorAppointmentApp.Repository;

namespace DoctorAppointmentApp.Service
{
    public class HospitalService
    {
        private readonly HospitalRepository<Patient>? _patientRepo;
        private readonly HospitalRepository<Doctor>? _doctorRepo;
        private readonly HospitalRepository<Appointment>? _appointmentRepo;

        public HospitalService(HospitalContext context)
        {
            _patientRepo = new HospitalRepository<Patient>(context);
            _doctorRepo = new HospitalRepository<Doctor>(context);
            _appointmentRepo = new HospitalRepository<Appointment>(context);
        }

        //CRUD for Patient
        public IEnumerable<Patient> GetAllPatients() => _patientRepo.GetAll();
        public Patient? GetPatientById(int id) => _patientRepo.GetById(id);
        public void AddPatient(Patient patient) => _patientRepo.Add(patient);
        public void UpdatePatient(Patient patient) => _patientRepo.Update(patient);
        public void DeletePatient(int id) => _patientRepo.Delete(id);

        //CRUD for Doctor
        public IEnumerable<Doctor> GetAllDoctors() => _doctorRepo.GetAll();
        public Doctor? GetDoctorById(int id) => _doctorRepo.GetById(id);
        public void AddDoctor(Doctor doctor) => _doctorRepo.Add(doctor);
        public void UpdateDoctor(Doctor doctor) => _doctorRepo.Update(doctor);
        public void DeleteDoctor(int id) => _doctorRepo.Delete(id);

        //CRUD for Appointment
        public IEnumerable<Appointment> GetAllAppointments() => _appointmentRepo.GetAll();
        public Appointment? GetAppointmentById(int id) => _appointmentRepo.GetById(id);
        public void UpdateAppointment(Appointment appointment) => _appointmentRepo.Update(appointment);
        public void DeleteAppointment(int id) => _appointmentRepo.Delete(id);

        public void BookAppointment(int patientId, int doctorId, DateTime date, string reason)
        {
            var patient = _patientRepo.GetById(patientId);
            var doctor = _doctorRepo.GetById(doctorId);

            if(patient == null)
            {
                throw new Exception("Patient not found.");
            }

            if (doctor == null)
            {
                throw new Exception("Doctor not found.");
            }

            var existingAppointments = _appointmentRepo.GetAll()
                .FirstOrDefault(a => a.DoctorId == doctorId && a.AppointmentDateTime == date);
            if (existingAppointments != null)
            {
                throw new Exception("The doctor is not available at the scheduled time. Please choose a different time slot.");
            }

            var appointment = new Appointment
            {
                DoctorId = doctorId,
                PatientId = patientId,
                AppointmentDateTime = date,
                AppointmentReason = reason
            };

            _appointmentRepo.Add(appointment);
            
        }

    }
}
