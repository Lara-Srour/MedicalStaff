using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests.DepartmentRequests
{
   
        public class GetAllDepartmentsRequest : GetAllRequest<DepartmentDTO>
        {

        }

        public class GetDepartmentByIdRequest : GetByIdRequest<DepartmentDTO>
        {
            public GetDepartmentByIdRequest(int id) : base(id) { }
        }

        public class DisplayRoomsInDepartmentRequest : IRequest<ApiResponse<IEnumerable<RoomDTO>>>
        {
            public string DepartmentName { get; }
            public DisplayRoomsInDepartmentRequest(string departmentName)
            {
                DepartmentName = departmentName;
            }
        }

        public class AddDepartmentRequest : AddRequest<DepartmentDTO>
        {
            public AddDepartmentRequest(DepartmentDTO department) : base(department) { }
        }

        public class UpdateDepartmentRequest : UpdateRequest<DepartmentDTO>
        {
            public UpdateDepartmentRequest(DepartmentDTO department) : base(department) { }
        }

        public class DeleteDepartmentRequest : DeleteRequest<DepartmentDTO>
        {
            public DeleteDepartmentRequest(int id) : base(id) { }
        }
    
}
