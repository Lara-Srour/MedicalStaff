namespace MedicalStaff.Application.DTOs
{
    public record PatientDTO(int Id, string? Name, int DoctorId, int NurseId, int RoomNumber) : IEntity
    {
        public int Id { get; set; } = Id;
      
    }
}
