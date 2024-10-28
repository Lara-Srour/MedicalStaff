using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using static MedicalStaff.Application.Requests.DepartmentRequests;


namespace MedicalStaff.Application.Handlers.Departments
{
    public class GetDepartmentByIdHandler(IDepartmentRepository _departmentRepository) : IRequestHandler<GetDepartmentByIdRequest, ApiResponse<DepartmentDTO>>
    {
        public async Task<ApiResponse<DepartmentDTO>> Handle(GetDepartmentByIdRequest request, CancellationToken cancellationToken)
        {   
            // Check if the department exists
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            if (department == null)
            {
                return ApiResponse<DepartmentDTO>.CreateErrorResponse($"Department with ID {request.Id} does not exist.");
            }
            return ApiResponse<DepartmentDTO>.CreateSuccessResponse(department.Adapt<DepartmentDTO>(), $"Department with ID {department.Id} is retrieved successfully.");

        }
    }
}
