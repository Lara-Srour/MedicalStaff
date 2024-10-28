using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using System.Xml.Linq;
using static MedicalStaff.Application.Requests.PatientRequests;


namespace MedicalStaff.Application.Handlers.Patients
{
    public class AddPatientHandler(IPatientRepository _patientRepository) : IRequestHandler<AddPatientRequest, ApiResponse<PatientDTO>>
    {
        public async Task<ApiResponse<PatientDTO>> Handle(AddPatientRequest request, CancellationToken cancellationToken)
        {
            var (name, doctorId, nurseId, roomNumber) = request;
            var patient = new Patient(name, doctorId, nurseId, roomNumber);
            await _patientRepository.AddPatientAsync(patient);
            
            return ApiResponse<PatientDTO>.CreateSuccessResponse(patient.Adapt<PatientDTO>(), $"Patient {patient.Id} is added successfully");
        }
    }
}