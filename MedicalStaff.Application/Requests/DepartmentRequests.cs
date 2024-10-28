using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class DepartmentRequests
    {
        public record GetAllDepartmentsRequest : GetAllRequest<DepartmentDTO>;

        public record GetDepartmentByIdRequest(int Id) : GetByIdRequest<DepartmentDTO>(Id);

        public record DisplayRoomsInDepartmentRequest(string DepartmentName) : IRequest<ApiResponse<IEnumerable<RoomDTO>>>;

        public record AddDepartmentRequest(string Name) : IRequest<ApiResponse<DepartmentDTO>>;

        public record UpdateDepartmentRequest(DepartmentDTO Department) : UpdateRequest<DepartmentDTO>(Department);

        public record DeleteDepartmentRequest(int Id) : DeleteRequest<DepartmentDTO>(Id);
    }
        
}
