using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Application;
using MedicalStaff.Domain;
using Microsoft.AspNetCore.Identity;
using static MedicalStaff.Application.Requests.DepartmentRequests;


namespace MedicalStaff.Application.Handlers.Departments
{
    public class AddDepartmentHandler(IDepartmentRepository _departmentRepository) : IRequestHandler<AddDepartmentRequest, ApiResponse<DepartmentDTO>>
    {
        public async Task<ApiResponse<DepartmentDTO>> Handle(AddDepartmentRequest request, CancellationToken cancellationToken)
        {
            var name = request.Name;
            var department = new Department(name);
            // Check if the department already exists
            await _departmentRepository.AddAsync(department);
            
            return ApiResponse<DepartmentDTO>.CreateSuccessResponse(department.Adapt<DepartmentDTO>(), $"Department {department.Id} is added successfully");
        }
    }
}