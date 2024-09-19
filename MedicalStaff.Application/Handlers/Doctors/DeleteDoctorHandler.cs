using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DoctorRequests;
namespace MedicalStaff.Application.Doctors
{
    public class DeleteDoctorHandler : IRequestHandler<DeleteDoctorRequest, ApiResponse<string>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<ApiResponse<string>> Handle(DeleteDoctorRequest request, CancellationToken cancellationToken)
        {
            // Check if the doctor exists
            var existingdoctor = await _doctorRepository.GetByIdAsync(request.Id);
            if (existingdoctor == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Doctor with ID {request.Id} does not exist and cannot be deleted.");
            }
            await _doctorRepository.DeleteAsync(request.Id);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Doctor with ID {request.Id} is deleted.");
        }
    }
}