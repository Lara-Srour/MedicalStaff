using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Application;
using MedicalStaff.Domain;
using MedicalStaff.Application.Requests.DepartmentRequests;


namespace MedicalStaff.Application.Departments
{
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentRequest, ApiResponse<DepartmentDTO>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public AddDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ApiResponse<DepartmentDTO>> Handle(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            //map DepartmentDTO to the entity Department
            var departmentDto = request.Entity;
            var department = departmentDto.Adapt<Department>();
            // Check if the department already exists
            var existingDepartment = await _departmentRepository.GetByIdAsync(department.Id);
            if (existingDepartment != null)
            {
                // Handle the error, e.g., throw an exception or return a specific error response
                return ApiResponse<DepartmentDTO>.CreateErrorResponse($"Department with ID {departmentDto.Id} already exists.");
            }
            await _departmentRepository.AddAsync(department);
            return ApiResponse<DepartmentDTO>.CreateSuccessResponse(departmentDto, $"Department {departmentDto.Id} is added successfully");
        }
    }
}