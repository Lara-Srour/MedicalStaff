using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using MedicalStaff.Application.Requests.DepartmentRequests;

namespace MedicalStaff.Application.Departments
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, ApiResponse<string>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public UpdateDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ApiResponse<string>> Handle(UpdateDepartmentRequest request, CancellationToken cancellationToken)
        {
            //map from DepartmentDTO to the entity Department
            var departmentDto = request.Entity;
            var department = departmentDto.Adapt<Department>();
            // Check if the department exists
            var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
            if (existingDepartment == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Department with ID {departmentDto.Id} does not exist.");
            }

            await _departmentRepository.UpadateDepartnmentAsync(department);
            return ApiResponse<string>.CreateSuccessResponse(default, $"Department {departmentDto.Id} is updated.");
        }
    }
}