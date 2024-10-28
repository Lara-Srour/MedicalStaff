using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;

namespace MedicalStaff.Application.Handlers.Patients
{
    public class GetAllPatientsHandler(IPatientRepository _patientRepository) : IRequestHandler<GetAllPatientsRequest, ApiResponse<IEnumerable<PatientDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<PatientDTO>>> Handle(GetAllPatientsRequest request, CancellationToken cancellationToken)
        {
            var patients = await _patientRepository.GetAllAsync();
            return ApiResponse<IEnumerable<PatientDTO>>.CreateSuccessResponse(patients.Adapt<IEnumerable<PatientDTO>>(), "Patients retrieved successfuly.");
        }
    }
}
