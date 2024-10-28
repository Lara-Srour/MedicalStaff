using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class DoctorRequests
    {
        public record GetAllDoctorsRequest : GetAllRequest<DoctorDTO>;
    

        public record GetDoctorByIdRequest(int Id) : GetByIdRequest<DoctorDTO>(Id);

        public record GetDoctorsBySpecialtyRequest(string Specialty) : IRequest<ApiResponse<IEnumerable<DoctorDTO>>>;

        public record GetDoctorPatientsRequest(int DoctorId) : IRequest<ApiResponse<IEnumerable<PatientDTO>>>;

        public record AddDoctorRequest(string Name, string Specialty) : IRequest<ApiResponse<DoctorDTO>>;

        public record UpdateDoctorRequest(DoctorDTO Doctor) : UpdateRequest<DoctorDTO>(Doctor);

        public record DeleteDoctorRequest(int Id) : DeleteRequest<DoctorDTO>(Id);
       
    }
}
