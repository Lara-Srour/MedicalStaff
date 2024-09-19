using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using MedicalStaff.Application.Requests.DepartmentRequests;

namespace MedicalStaff.Application.Departments
{
    public class DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest, ApiResponse<string>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DeleteDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

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