using MediatR;
using MedicalStaff.Application.DTOs;

namespace MedicalStaff.Application.Requests
{
    public class PatientRequests
    {

        public class GetAllPatientsRequest : GetAllRequest<PatientDTO>
        {

        }

        public class GetPatientByIdRequest : GetByIdRequest<PatientDTO>
        {
            public GetPatientByIdRequest(int id) : base(id) { }
        }

        public class AddPatientRequest : AddRequest<PatientDTO>
        {
            public AddPatientRequest(PatientDTO patient) : base(patient) { }
        }

        public class UpdatePatientRequest : UpdateRequest<PatientDTO>
        {
            public UpdatePatientRequest(PatientDTO patient) : base(patient) { }
        }

        public class DeletePatientRequest : DeleteRequest<PatientDTO>
        {
            public DeletePatientRequest(int id) : base(id) { }

        }
    }
}