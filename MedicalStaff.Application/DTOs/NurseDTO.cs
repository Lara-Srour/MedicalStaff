namespace MedicalStaff.Application.DTOs
{
    public class NurseDTO : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }
    }
}
