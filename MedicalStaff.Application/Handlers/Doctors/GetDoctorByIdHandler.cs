using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Handlers.Doctors
{
    public class GetDoctorByIdHandler : IRequestHandler<GetDoctorByIdRequest, ApiResponse<DoctorDTO>>
    {
        private readonly IDoctorRepository _doctorRepository;
        public GetDoctorByIdHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<DoctorDTO>> Handle(GetDoctorByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the doctor exists
            var doctor = await _doctorRepository.GetByIdAsync(request.Id);
            var doctorDto = doctor.Adapt<DoctorDTO>();
            if (doctorDto == null)
            {
                return ApiResponse<DoctorDTO>.CreateErrorResponse($"Doctor with ID {request.Id} does not exist.");
            }
            
            return ApiResponse<DoctorDTO>.CreateSuccessResponse(doctorDto, $"Doctor {doctorDto.Id} is retrieved successfully.");
        }
    }
}
