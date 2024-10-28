namespace MedicalStaff.Application.DTOs
{
    public record RoomDTO(int Id, int Number, string? DepartmentName, bool IsAvailable = true) : IEntity
    {
        public int Id { get; set; } = Id;
    }
}
