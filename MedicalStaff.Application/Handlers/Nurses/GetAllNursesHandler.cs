using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;

namespace MedicalStaff.Application.Handlers.Nurses
{
    public class GetAllNursesHandler(INurseRepository _nurseRepository) : IRequestHandler<GetAllNursesRequest, ApiResponse<IEnumerable<NurseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<NurseDTO>>> Handle(GetAllNursesRequest request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseRepository.GetAllAsync();
            return ApiResponse<IEnumerable<NurseDTO>>.CreateSuccessResponse(nurses.Adapt<IEnumerable<NurseDTO>>(), $"Nurses retrieved successfuly.");
        }
    }
}
