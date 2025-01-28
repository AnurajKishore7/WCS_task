namespace ClinicManagementAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Age { get; set; }
        = string.Empty;
        public string Mobile { get; set; } = string.Empty;

    }
}
