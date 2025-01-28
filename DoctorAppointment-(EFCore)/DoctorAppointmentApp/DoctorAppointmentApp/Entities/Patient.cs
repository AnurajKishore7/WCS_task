namespace DoctorAppointmentApp.Entities
{
    public class Patient
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Mobile { get; set; } = string.Empty;

        //Navigation Property
        public ICollection<Appointment>? Appointments { get; set; }

        public override string ToString()
        {
            return $@"PatientId: {Id}
                Name: {Name}
                Gender: {Gender}
                Age: {Age}
                Mobile: {Mobile}";
        }
    }
}
