using Microsoft.AspNetCore.Mvc;
using ClinicManagementAPI.Models;

namespace ClinicManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        static IList<Patient> patients = new List<Patient>()
        {
            new Patient { Id = 1, Name = "John Doe", Gender = "Male", Age = "30", Mobile = "9876543210" },
            new Patient { Id = 2, Name = "Jane Smith", Gender = "Female", Age = "25", Mobile = "8765432109" },
            new Patient { Id = 3, Name = "Chris Johnson", Gender = "Non-Binary", Age = "28", Mobile = "7654321098" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            if (patients.Count == 0)
            {
                return Ok(new { message = "No patients in the database." });
            }

            return Ok(patients);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Patient> GetPatientById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid patient ID." });
            }

            var patient = patients.FirstOrDefault(x => x.Id == id);

            if (patient == null)
            {
                return NotFound(new { message = $"Patient with Id {id} not found." });
            }

            return Ok(patient);
        }

        [HttpPost]
        public ActionResult AddPatient(Patient patient)
        {
            if (patient == null || string.IsNullOrWhiteSpace(patient.Name))
            {
                return BadRequest(new { message = "Invalid patient details." });
            }

            patient.Id = patients.Max(p => p.Id) + 1;
            patients.Add(patient);

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Patient> UpdatePatient(int id, Patient updatedPatient)
        {
            if (updatedPatient == null)
            {
                return BadRequest(new { message = "Updated patient details cannot be null." });
            }

            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid patient ID." });
            }

            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound(new { message = $"Patient with Id {id} not found. Update operation failed." });
            }

            patient.Name = updatedPatient.Name;
            patient.Gender = updatedPatient.Gender;
            patient.Age = updatedPatient.Age;
            patient.Mobile = updatedPatient.Mobile;

            return Ok(patient);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeletePatient(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { message = "Invalid patient ID." });
            }

            var patient = patients.FirstOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return NotFound(new { message = $"Patient with Id {id} not found. Deletion failed." });
            }

            patients.Remove(patient);

            return Ok(new { message = "Patient deleted successfully." });
        }
    }
}
