using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DoctorRequests;

namespace MedicalStaff.Application.Handlers.Doctors
{
    public class GetAllDoctorHandler : IRequestHandler<GetAllDoctorsRequest, ApiResponse<IEnumerable<DoctorDTO>>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetAllDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<IEnumerable<DoctorDTO>>> Handle(GetAllDoctorsRequest request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetAllAsync();
            var doctorDtos = doctor.Adapt<IEnumerable<DoctorDTO>>();
            return ApiResponse<IEnumerable<DoctorDTO>>.CreateSuccessResponse(doctorDtos, $"Doctors retrieved successfuly.");
        }
    }
}
