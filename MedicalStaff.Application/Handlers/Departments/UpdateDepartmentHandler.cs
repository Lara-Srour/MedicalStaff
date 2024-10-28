using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DepartmentRequests;

namespace MedicalStaff.Application.Handlers.Departments
{
    public class UpdateDepartmentHandler(IDepartmentRepository _departmentRepository) : IRequestHandler<UpdateDepartmentRequest, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            //map from DepartmentDTO to the entity Department
            var departmentDto = request.Entity;
            var department = departmentDto.Adapt<Department>();
            // Check if the department exists
            var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
            if (existingDepartment == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Department with ID {department.Id} does not exist.");
            }

            await _departmentRepository.UpadateDepartnmentAsync(department);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Department {department.Id} is updated.");
        }
    }
}