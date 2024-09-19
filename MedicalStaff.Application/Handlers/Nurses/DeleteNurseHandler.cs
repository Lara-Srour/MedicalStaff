using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;
namespace MedicalStaff.Application.Handlers.Nurses
{
    public class DeleteNurseHandler : IRequestHandler<DeleteNurseRequest, ApiResponse<string>>
    {
        private readonly INurseRepository _nurseRepository;

        public DeleteNurseHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<ApiResponse<string>> Handle(DeleteNurseRequest request, CancellationToken cancellationToken)
        {
            // Check if the nurse exists
            var existingnurse = await _nurseRepository.GetByIdAsync(request.Id);
            if (existingnurse == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Nurse with ID {request.Id} does not exist and cannot be deleted.");
            }
            await _nurseRepository.DeleteAsync(request.Id);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Nurse with ID {request.Id} is deleted.");
        }
    }
}