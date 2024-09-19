namespace MedicalStaff.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string? DepartmentName { get; set; }
        public bool IsAvailable { get; set; } = true;

    }
}
