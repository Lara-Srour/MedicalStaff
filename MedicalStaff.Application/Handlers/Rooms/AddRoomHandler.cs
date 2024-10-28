using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace MedicalStaff.Application.Handlers.Rooms
{
    public class AddRoomHandler(IRoomRepository _roomRepository) : IRequestHandler<AddRoomRequest, ApiResponse<RoomDTO>>
    {
        public async Task<ApiResponse<RoomDTO>> Handle(AddRoomRequest request, CancellationToken cancellationToken)
        {
            var (number, departmentName) = request;
            var room = new Room(number, departmentName);
            await _roomRepository.AddRoomAsync(room);
            return ApiResponse<RoomDTO>.CreateSuccessResponse(room.Adapt<RoomDTO>(), $"Room {room.Id} is added successfully");
        }
    }
}