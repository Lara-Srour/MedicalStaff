using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;

namespace MedicalStaff.Application.Handlers.Patients
{
    public class GetAllPatientsHandler : IRequestHandler<GetAllPatientsRequest, ApiResponse<IEnumerable<PatientDTO>>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllPatientsHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ApiResponse<IEnumerable<PatientDTO>>> Handle(GetAllPatientsRequest request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();

            // map to Dto
            var patientDtos = patients.Adapt<IEnumerable<PatientDTO>>();
            return ApiResponse<IEnumerable<PatientDTO>>.CreateSuccessResponse(patientDtos, "Patients retrieved successfuly.");
        }
    }
}
