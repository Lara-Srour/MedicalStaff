using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;

namespace MedicalStaff.Application.Requests
{
    public class RoomRequests
    {

        public record GetAllRoomsRequest : GetAllRequest<RoomDTO>;

        public record GetRoomByIdRequest(int Id) : GetByIdRequest<RoomDTO>(Id);

        public record DisplayAvailableRoomsRequest(string DepartmentName) : IRequest<ApiResponse<IEnumerable<RoomDTO>>>;

        public record AddRoomRequest(int Number, string DepartmentName) : IRequest<ApiResponse<RoomDTO>>;

        public record UpdateRoomRequest(RoomDTO Room) : UpdateRequest<RoomDTO>(Room);

        public record DeleteRoomRequest(int Id) : DeleteRequest<RoomDTO>(Id);
        
    }

}
