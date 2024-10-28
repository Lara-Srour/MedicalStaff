using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.DepartmentRequests;
using System.Collections.Generic;

namespace MedicalStaff.Application.Handlers.Departments
{
    public class GetAllDepartmentsHandler(IDepartmentRepository _departmentRepository) : IRequestHandler<GetAllDepartmentsRequest, ApiResponse<IEnumerable<DepartmentDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<DepartmentDTO>>> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            return ApiResponse<IEnumerable<DepartmentDTO>>.CreateSuccessResponse(departments.Adapt<IEnumerable<DepartmentDTO>>(), $"Departments retrieved successfuly.");
        }
    }
}
