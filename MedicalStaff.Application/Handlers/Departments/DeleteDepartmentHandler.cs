using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DepartmentRequests;

namespace MedicalStaff.Application.Handlers.Departments
{
    public class DeleteDepartmentHandler(IDepartmentRepository _departmentRepository) : IRequestHandler<DeleteDepartmentRequest, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(DeleteDepartmentRequest request, CancellationToken cancellationToken)
        {
            // Check if the department exists
            var existingDepartment = await _departmentRepository.GetByIdAsync(request.Id);
            if (existingDepartment == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Department with ID {request.Id} does not exist and cannot be deleted.");
            }
            await _departmentRepository.DeleteDepartmentAsync(request.Id);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Department with ID {request.Id} is deleted.");
        }
    }
}