namespace MedicalStaff.Application.DTOs
{
    public record NurseDTO(int Id, string? Name, string? DepartmentName) : IEntity
    {
        public int Id { get; set; } = Id;
        
    }
}
