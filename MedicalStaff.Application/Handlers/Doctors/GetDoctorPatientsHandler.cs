using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using System.Collections.Generic;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Handlers.Doctors
{
    public class GetDoctorPatientsHandler(IDoctorRepository _doctorRepository) : IRequestHandler<GetDoctorPatientsRequest, ApiResponse<IEnumerable<PatientDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<PatientDTO>>> Handle(GetDoctorPatientsRequest request, CancellationToken cancellationToken)
        {
            var patients = await _doctorRepository.GetDoctorPatientsAsync(request.DoctorId);
           
            if (patients == null || !patients.Any())
            {
                return ApiResponse<IEnumerable<PatientDTO>>.CreateErrorResponse($"No patients found for doctor {request.DoctorId}.");
            }
            return ApiResponse<IEnumerable<PatientDTO>>.CreateSuccessResponse(patients.Adapt<IEnumerable<PatientDTO>>(), $"List of patients of doctor {request.DoctorId} is successfully retrieved.");
        }
    }
}
