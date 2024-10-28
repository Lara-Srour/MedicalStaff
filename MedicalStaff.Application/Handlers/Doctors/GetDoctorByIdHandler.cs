using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Handlers.Doctors
{
    public class GetDoctorByIdHandler(IDoctorRepository _doctorRepository) : IRequestHandler<GetDoctorByIdRequest, ApiResponse<DoctorDTO>>
    {
        public async Task<ApiResponse<DoctorDTO>> Handle(GetDoctorByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the doctor exists
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);
            
            if (doctor == null)
            {
                return ApiResponse<DoctorDTO>.CreateErrorResponse($"Doctor with ID {request.Id} does not exist.");
            }
            
            return ApiResponse<DoctorDTO>.CreateSuccessResponse(doctor.Adapt<DoctorDTO>(), $"Doctor {doctor.Id} is retrieved successfully.");
        }
    }
}
