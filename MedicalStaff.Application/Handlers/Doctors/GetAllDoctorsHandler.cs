using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Handlers.Doctors
{
    public class GetAllDoctorHandler(IDoctorRepository _doctorRepository) : IRequestHandler<GetAllDoctorsRequest, ApiResponse<IEnumerable<DoctorDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<DoctorDTO>>> Handle(GetAllDoctorsRequest request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetAllAsync();
            return ApiResponse<IEnumerable<DoctorDTO>>.CreateSuccessResponse(doctor.Adapt<IEnumerable<DoctorDTO>>(), $"Doctors retrieved successfuly.");
        }
    }
}
