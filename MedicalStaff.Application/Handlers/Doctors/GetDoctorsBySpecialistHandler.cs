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
    public class GetDoctorsBySpecialistHandler : IRequestHandler<GetDoctorsBySpecialtyRequest, ApiResponse<IEnumerable<DoctorDTO>>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorsBySpecialistHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<IEnumerable<DoctorDTO>>> Handle(GetDoctorsBySpecialtyRequest request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetDoctorsBySpecialtyAsync(request.Specialty);
            // Check if any rooms were found
            if (doctors == null || !doctors.Any())
            {
                return ApiResponse<IEnumerable<DoctorDTO>>.CreateErrorResponse($"No doctors with this specialty found.");
            }
            var doctorDtos = doctors.Adapt<IEnumerable<DoctorDTO>>();
            return ApiResponse<IEnumerable<DoctorDTO>>.CreateSuccessResponse(doctorDtos, $"List of doctors of {request.Specialty} specialist is successfully retrieved.");
        }
    }       
}