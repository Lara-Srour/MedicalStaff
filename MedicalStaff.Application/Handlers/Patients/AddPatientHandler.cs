using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.PatientRequests;


namespace MedicalStaff.Application.Patients
{
    public class AddPatientHandler : IRequestHandler<AddPatientRequest, ApiResponse<PatientDTO>>
    {
        private readonly IPatientRepository _patientRepository;

        public AddPatientHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<ApiResponse<PatientDTO>> Handle(AddPatientRequest request, CancellationToken cancellationToken)
        {
            //map PatientDTO to the entity Patient
            var patientDto = request.Entity;
            // Check if the patient already exists
            var existingPatient = await _patientRepository.GetByIdAsync(patientDto.Id);
            if (existingPatient != null)
            {
                // Handle the error, e.g., throw an exception or return a specific error response
                return ApiResponse<PatientDTO>.CreateErrorResponse($"Patient with ID {patientDto.Id} already exists.");
            }
            //map Dto to Entity
            var patient = patientDto.Adapt<Patient>();
            await _patientRepository.AddPatientAsync(patient);
            return ApiResponse<PatientDTO>.CreateSuccessResponse(patientDto, $"Patient {patientDto.Id} is added successfully");
        }
    }
}