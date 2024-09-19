using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;

namespace MedicalStaff.Application.Handlers.Patients
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdRequest, ApiResponse<PatientDTO>>
    {
        private readonly IPatientRepository _patientRepository;
        public GetPatientByIdHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ApiResponse<PatientDTO>> Handle(GetPatientByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the patient exists
            var patient = await _patientRepository.GetByIdAsync(request.Id);

            //map patient to Dto
            var patientDto = patient.Adapt<PatientDTO>();
            if (patientDto == null)
            {
                return ApiResponse<PatientDTO>.CreateErrorResponse($"Patient with ID {request.Id} does not exist.");
            }
            return ApiResponse<PatientDTO>.CreateSuccessResponse(patientDto, $"Patient {patientDto.Id} is retrieved successfully.");
        }
    }
}
