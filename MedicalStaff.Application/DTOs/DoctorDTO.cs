namespace MedicalStaff.Application.DTOs
{
    public record DoctorDTO(int Id, string? Name, string? Specialty) : IEntity
    {
        public int Id { get; set; } = Id;
        
    }
}
