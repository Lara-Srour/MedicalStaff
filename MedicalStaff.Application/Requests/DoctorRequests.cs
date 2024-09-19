using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class DoctorRequests
    {
        public class GetAllDoctorsRequest : GetAllRequest<DoctorDTO>
        {

        }

        public class GetDoctorByIdRequest : GetByIdRequest<DoctorDTO>
        {
            public GetDoctorByIdRequest(int id) : base(id) { }
        }

        public class GetDoctorsBySpecialtyRequest : IRequest<ApiResponse<IEnumerable<DoctorDTO>>>
        {
            public string Specialty { get; }
            public GetDoctorsBySpecialtyRequest(string specialty)
            {
                Specialty = specialty;
            }
        }

        public class GetDoctorPatientsRequest : IRequest<ApiResponse<IEnumerable<PatientDTO>>>
        {
            public int DoctorId { get; }
            public GetDoctorPatientsRequest(int doctorId)
            {
                DoctorId = doctorId;
            }
        }

        public class AddDoctorRequest : AddRequest<DoctorDTO>
        {
            public AddDoctorRequest(DoctorDTO doctor) : base(doctor) { }
        }

        public class UpdateDoctorRequest : UpdateRequest<DoctorDTO>
        {
            public UpdateDoctorRequest(DoctorDTO doctor) : base(doctor) { }
        }

        public class DeleteDoctorRequest : DeleteRequest<DoctorDTO>
        {
            public DeleteDoctorRequest(int id) : base(id) { }
        }
    }
}
