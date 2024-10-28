using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;

namespace MedicalStaff.Application.Handlers.Nurses
{
    public class GetNurseByIdHandler(INurseRepository _nurseRepository) : IRequestHandler<GetNurseByIdRequest, ApiResponse<NurseDTO>>
    {
        public async Task<ApiResponse<NurseDTO>> Handle(GetNurseByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the nurse exists
            var nurse = await _nurseRepository.GetByIdAsync(request.Id);
           
            if (nurse == null)
            {
                return ApiResponse<NurseDTO>.CreateErrorResponse($"Nurse with ID {request.Id} does not exist.");
            }
            
            return ApiResponse<NurseDTO>.CreateSuccessResponse(nurse.Adapt<NurseDTO>(), $"Nurse {nurse.Id} is retrieved successfully.");
        }
    }
}
