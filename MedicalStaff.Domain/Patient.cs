namespace MedicalStaff.Domain
{
    public class Patient
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DoctorId { get; set; }
        public int NurseId { get; set; } 
        public int RoomNumber { get; set; }

        public Patient(string name, int doctorId, int nurseId, int roomNumber)
        {
            Name = name;
            DoctorId = doctorId;
            NurseId = nurseId;
            RoomNumber = roomNumber;
        }
        public Patient(){ }
    }

}
