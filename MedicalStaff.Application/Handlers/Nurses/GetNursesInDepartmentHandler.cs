using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.NurseRequests;


namespace MedicalStaff.Application.Handlers.Nurses
{
    public class GetNursesInDepartmentHandler(INurseRepository _nurseRepository) : IRequestHandler<GetNursesInDepartmentRequest, ApiResponse<IEnumerable<NurseDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<NurseDTO>>> Handle(GetNursesInDepartmentRequest request, CancellationToken cancellationToken)
        {
            var nurses = await _nurseRepository.GetNursesInDepartmentAsync(request.DepartmentName);

            if (nurses == null || !nurses.Any())
            {
                return ApiResponse<IEnumerable<NurseDTO>>.CreateErrorResponse($"No nurses found in {request.DepartmentName} department");
            }
            return ApiResponse<IEnumerable<NurseDTO>>.CreateSuccessResponse(nurses.Adapt<IEnumerable<NurseDTO>>(), $"Nurses in {request.DepartmentName} departmment are retrieved successfully");
        }
    }
}