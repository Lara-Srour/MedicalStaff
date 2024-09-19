using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;

namespace MedicalStaff.Application.Handlers.Patients
{
    public class DeletePatientHandler : IRequestHandler<DeletePatientRequest, ApiResponse<string>>
    {
        private readonly IPatientRepository _patientRepository;

        public DeletePatientHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ApiResponse<string>> Handle(DeletePatientRequest request, CancellationToken cancellationToken)
        {
            // Check if the patient exists
            var existingpatient = await _patientRepository.GetByIdAsync(request.Id);
            if (existingpatient == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Patient with ID {request.Id} does not exist and cannot be deleted.");
            }
            await _patientRepository.DeletePatientAsync(existingpatient.Id);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Patient with ID {existingpatient.Id} is deleted.") ;
        }
    }
}