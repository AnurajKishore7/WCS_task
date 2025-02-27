﻿using ClinicManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        static IList<Doctor> doctors = new List<Doctor>() {
            new Doctor { Id = 1, Name = "Dr. Anuraj Kishore", Gender = "Male", Age = 45, Specialization = "Cardiology", Mobile = "1234567890" },
            new Doctor { Id = 2, Name = "Dr. Joselin Shinita", Gender = "Female", Age = 38, Specialization = "Pediatrics", Mobile = "9876543210" },
            new Doctor { Id = 3, Name = "Dr. Jabir Sheriff", Gender = "Male", Age = 50, Specialization = "Orthopedics", Mobile = "5551234567" }
        };

        private bool IsValidId(int id) => id > 0;

        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetAllDoctors()
        {
            if (doctors.Count == 0)
            {
                return Ok(new { message = "No doctors in the database." });
            }

            return Ok(doctors);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Doctor> GetDoctorById(int id)
        {
            if (!IsValidId(id))
            {
                return BadRequest(new { message = "Invalid doctor ID." });
            }

            var doctor = doctors.FirstOrDefault(x => x.Id == id);

            if (doctor == null)
            {
                return NotFound(new { message = $"Doctor with ID {id} not found." });
            }

            return Ok(doctor);
        }

        [HttpGet("specialization/{specialization}")]
        public ActionResult<IEnumerable<Doctor>> GetDoctorsBySpecialization(string specialization)
        {
            var specializedDoctors = doctors
                .Where(d => d.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!specializedDoctors.Any())
            {
                return NotFound(new { message = $"No doctors found with specialization: {specialization}" });
            }

            return Ok(specializedDoctors);
        }

        [HttpPost]
        public ActionResult AddDoctor(Doctor doctor)
        {
            if (doctor == null || string.IsNullOrWhiteSpace(doctor.Name) ||
                string.IsNullOrWhiteSpace(doctor.Specialization) ||
                string.IsNullOrWhiteSpace(doctor.Mobile) || doctor.Age <= 0)
            {
                return BadRequest(new { message = "Invalid doctor details." });
            }

            doctor.Id = doctors.Max(p => p.Id) + 1;
            doctors.Add(doctor);

            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Doctor> UpdateDoctor(int id, Doctor updatedDoctor)
        {
            if (updatedDoctor == null || !IsValidId(id))
            {
                return BadRequest(new { message = "Invalid input." });
            }

            var doctor = doctors.FirstOrDefault(p => p.Id == id);

            if (doctor == null)
            {
                return NotFound(new { message = $"Doctor with ID {id} not found. Update failed." });
            }

            doctor.Name = updatedDoctor.Name;
            doctor.Gender = updatedDoctor.Gender;
            doctor.Age = updatedDoctor.Age;
            doctor.Specialization = updatedDoctor.Specialization;
            doctor.Mobile = updatedDoctor.Mobile;

            return Ok(doctor);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteDoctor(int id)
        {
            if (!IsValidId(id))
            {
                return BadRequest(new { message = "Invalid doctor ID." });
            }

            var doctor = doctors.FirstOrDefault(p => p.Id == id);

            if (doctor == null)
            {
                return NotFound(new { message = $"Doctor with ID {id} not found. Deletion failed." });
            }

            doctors.Remove(doctor);

            return NoContent();
        }
    }
}
