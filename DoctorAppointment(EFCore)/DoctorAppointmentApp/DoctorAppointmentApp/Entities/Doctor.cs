namespace DoctorAppointmentApp.Entities
{
    public class Doctor
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;

        //Navigation Propery
        public ICollection<Appointment>? Appointments { get; set; }

        public override string ToString()
        {
            return $@"DoctorId: {Id}
                Name: {Name}
                Gender: {Gender}
                Specializatin: {Specialization}
                Mobile: {Mobile}
                Availability: {Availability}";
        }
    }
}
