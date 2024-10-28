using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using System.Collections.Generic;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Doctors
{
    public class GetDoctorsBySpecialistHandler(IDoctorRepository _doctorRepository) : IRequestHandler<GetDoctorsBySpecialtyRequest, ApiResponse<IEnumerable<DoctorDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<DoctorDTO>>> Handle(GetDoctorsBySpecialtyRequest request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetDoctorsBySpecialtyAsync(request.Specialty);
            // Check if any rooms were found
            if (doctors == null || !doctors.Any())
            {
                return ApiResponse<IEnumerable<DoctorDTO>>.CreateErrorResponse($"No doctors with this specialty found.");
            }
           
            return ApiResponse<IEnumerable<DoctorDTO>>.CreateSuccessResponse(doctors.Adapt<IEnumerable<DoctorDTO>>(), $"List of doctors of {request.Specialty} specialist is successfully retrieved.");
        }
    }       
}