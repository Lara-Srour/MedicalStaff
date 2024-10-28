namespace MedicalStaff.Application.DTOs
{
    public record DepartmentDTO(int Id, string? Name) : IEntity
    {
        public int Id { get; set; } = Id;
    }
    
}