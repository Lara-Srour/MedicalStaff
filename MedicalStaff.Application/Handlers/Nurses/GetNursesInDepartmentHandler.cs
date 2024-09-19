using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;


namespace MedicalStaff.Application.Handlers.Nurses
{
    public class GetNursesInDepartmentHandler : IRequestHandler<GetNursesInDepartmentRequest, ApiResponse<IEnumerable<NurseDTO>>>
    {
        private readonly INurseRepository _nurseRepository;

        public GetNursesInDepartmentHandler(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<ApiResponse<IEnumerable<NurseDTO>>> Handle(GetNursesInDepartmentRequest request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseRepository.GetNursesInDepartmentAsync(request.DepartmentName);
            var nurseDtos = nurses.Adapt<IEnumerable<NurseDTO>>();

            if (nurseDtos == null || !nurseDtos.Any())
            {
                return ApiResponse<IEnumerable<NurseDTO>>.CreateErrorResponse($"No nurses found in {request.DepartmentName} department");
            }
            return ApiResponse<IEnumerable<NurseDTO>>.CreateSuccessResponse(nurseDtos, $"Nurses in {request.DepartmentName} departmment are retrieved successfully");
        }
    }
}