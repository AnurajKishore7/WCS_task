namespace ClinicManagementAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Specialization { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
    }
}
