using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;

namespace MedicalStaff.Application.Handlers.Patients
{
    public class GetPatientByIdHandler(IPatientRepository _patientRepository) : IRequestHandler<GetPatientByIdRequest, ApiResponse<PatientDTO>>
    {
        public async Task<ApiResponse<PatientDTO>> Handle(GetPatientByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the patient exists
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            //map patient to Dto
            if (patient == null)
            {
                return ApiResponse<PatientDTO>.CreateErrorResponse($"Patient with ID {request.Id} does not exist.");
            }
            return ApiResponse<PatientDTO>.CreateSuccessResponse(patient.Adapt<PatientDTO>(), $"Patient {patient.Id} is retrieved successfully.");
        }
    }
}
