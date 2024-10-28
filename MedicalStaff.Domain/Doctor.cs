namespace MedicalStaff.Domain

{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialty { get; set; }

        public Doctor(string name, string specialty)
        {
            Name = name;
            Specialty = specialty;
        }
        public Doctor() { }
    }
}
