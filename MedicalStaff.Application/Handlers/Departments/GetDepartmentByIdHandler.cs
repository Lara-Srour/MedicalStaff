using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Application.Requests.DepartmentRequests;


namespace MedicalStaff.Application.Handlers.Departments
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdRequest, ApiResponse<DepartmentDTO>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        public GetDepartmentByIdHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ApiResponse<DepartmentDTO>> Handle(GetDepartmentByIdRequest request, CancellationToken cancellationToken)
        {   
            // Check if the department exists
            var department = await _departmentRepository.GetByIdAsync(request.Id);
            var departmentDto = department.Adapt<DepartmentDTO>();
            if (departmentDto == null)
            {
                return ApiResponse<DepartmentDTO>.CreateErrorResponse($"Department with ID {request.Id} does not exist.");
            }
            return ApiResponse<DepartmentDTO>.CreateSuccessResponse(departmentDto, $"Department with ID {department.Id} is retrieved successfully.");

        }
    }
}
