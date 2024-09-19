namespace MedicalStaff.Application.DTOs
{
    public class PatientDTO : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; }
        public int RoomNumber { get; set; }
    }
}
