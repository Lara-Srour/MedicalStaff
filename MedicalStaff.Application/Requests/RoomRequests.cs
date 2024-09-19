using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class RoomRequests
    {

        public class GetAllRoomsRequest : GetAllRequest<RoomDTO>
        {

        }

        public class GetRoomByIdRequest : GetByIdRequest<RoomDTO>
        {
            public GetRoomByIdRequest(int id) : base(id) { }
        }

        public class DisplayAvailableRoomsRequest : IRequest<ApiResponse<IEnumerable<RoomDTO>>>
        {
            public string DepartmentName { get; }
            public DisplayAvailableRoomsRequest(string departmentName)
            {
                DepartmentName = departmentName;
            }
        }

        public class AddRoomRequest : AddRequest<RoomDTO>
        {
            public AddRoomRequest(RoomDTO room) : base(room) { }
        }

        public class UpdateRoomRequest : UpdateRequest<RoomDTO>
        {
            public UpdateRoomRequest(RoomDTO room) : base(room) { }
        }

        public class DeleteRoomRequest : DeleteRequest<RoomDTO>
        {
            public DeleteRoomRequest(int id) : base(id) { }
        }
    }

}
