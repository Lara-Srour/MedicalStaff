using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using MedicalStaff.Application.Requests.DepartmentRequests;
using System.Collections.Generic;

namespace MedicalStaff.Application.Handlers.Departments
{
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsRequest, ApiResponse<IEnumerable<DepartmentDTO>>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ApiResponse<IEnumerable<DepartmentDTO>>> Handle(GetAllDepartmentsRequest request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync();
            var departmentDtos = departments.Adapt<IEnumerable<DepartmentDTO>>();
            return ApiResponse<IEnumerable<DepartmentDTO>>.CreateSuccessResponse(departmentDtos, $"Departments retrieved successfuly.");
        }
    }
}
