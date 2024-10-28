using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;

namespace MedicalStaff.Application.Handlers.Rooms
{
    public class GetRoomByIdHandler(IRoomRepository _roomRepository) : IRequestHandler<GetRoomByIdRequest, ApiResponse<RoomDTO>>
    {
        public async Task<ApiResponse<RoomDTO>> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the room exists
            var room = await _roomRepository.GetByIdAsync(request.Id);
            
            if (room == null)
            {
                return ApiResponse<RoomDTO>.CreateErrorResponse($"Room with ID {request.Id} does not exist.");
            }
            
            return ApiResponse<RoomDTO>.CreateSuccessResponse(room.Adapt<RoomDTO>(), $"Room {room.Id} is retrieved successfully.");
        }
    }
}
