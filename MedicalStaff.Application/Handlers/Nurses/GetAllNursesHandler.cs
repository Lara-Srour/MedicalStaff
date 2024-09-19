using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;

namespace MedicalStaff.Application.Handlers.Nurses
{
    public class GetAllNursesHandler : IRequestHandler<GetAllNursesRequest, ApiResponse<IEnumerable<NurseDTO>>>
    {
        private readonly INurseRepository _nurseRepository;

        public GetAllNursesHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<ApiResponse<IEnumerable<NurseDTO>>> Handle(GetAllNursesRequest request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseRepository.GetAllAsync();
            var nurseDtos = nurses.Adapt<IEnumerable<NurseDTO>>();
            return ApiResponse<IEnumerable<NurseDTO>>.CreateSuccessResponse(nurseDtos, $"Nurses retrieved successfuly.");
        }
    }
}
