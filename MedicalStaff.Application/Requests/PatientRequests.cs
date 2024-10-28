using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class PatientRequests
    {

        public record GetAllPatientsRequest : GetAllRequest<PatientDTO>;

        public record GetPatientByIdRequest(int Id) : GetByIdRequest<PatientDTO>(Id);

        public record AddPatientRequest(string Name, int DoctorId, int NurseId, int RoomNumber) : IRequest<ApiResponse<PatientDTO>>;

        public record UpdatePatientRequest(PatientDTO Patient) : UpdateRequest<PatientDTO>(Patient);
        public record DeletePatientRequest(int Id) : DeleteRequest<PatientDTO>(Id);
        
    }
}