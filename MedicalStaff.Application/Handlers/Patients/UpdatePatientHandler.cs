using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;

namespace MedicalStaff.Application.Handlers.Patients
{
    public class UpdatePatientHandler(IPatientRepository _patientRepository) : IRequestHandler<UpdatePatientRequest, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(UpdatePatientRequest request, CancellationToken cancellationToken)
        {   
            //map from PatientDTO to the entity Patient
            var patientDto = request.Entity;
            var patient = patientDto.Adapt<Patient>();
            // Check if the patient exists
            var existingPatient = await _patientRepository.GetByIdAsync(patient.Id);
            if (existingPatient == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Patient with ID {patient.Id} does not exist.");
            }

            await _patientRepository.UpdatePatientAsync(patient);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Patient {patient.Id} is updated.");
        }
    }
}