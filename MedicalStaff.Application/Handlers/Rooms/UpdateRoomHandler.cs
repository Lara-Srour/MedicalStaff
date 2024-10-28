using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;

namespace MedicalStaff.Application.Handlers.Rooms
{
    public class UpdateRoomHandler(IRoomRepository _roomRepository) : IRequestHandler<UpdateRoomRequest, ApiResponse<string>>
    {
        public async Task<ApiResponse<string>> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
        {
            //map from RoomDTO to the entity Room
            var roomDto = request.Entity;
            var room = roomDto.Adapt<Room>();
            // Check if the room exists
            var existingRoom = await _roomRepository.GetByIdAsync(room.Id);
            if (existingRoom == null)
            {
                return ApiResponse<string>.CreateErrorResponse($"Room with ID {room.Id} does not exist.");
            }

            // Update existing nurse properties
            
            existingRoom.DepartmentName = roomDto.DepartmentName;
            

            await _roomRepository.UpdateRoomAsync(existingRoom);           
            return ApiResponse<string>.CreateSuccessResponse(default, $"Room {room.Id} is updated.");
        }
    }
} 