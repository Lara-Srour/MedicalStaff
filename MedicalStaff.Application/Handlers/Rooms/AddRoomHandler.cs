using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;


namespace MedicalStaff.Application.Rooms
{
    public class AddRoomHandler : IRequestHandler<AddRoomRequest, ApiResponse<RoomDTO>>
    {
        private readonly IRoomRepository _roomRepository;

        public AddRoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ApiResponse<RoomDTO>> Handle(AddRoomRequest request, CancellationToken cancellationToken)
        {
            //map RoomDTO to the entity Room
            var roomDto = request.Entity;
            var room = roomDto.Adapt<Room>();
            // Check if the room already exists
            var existingRoom = await _roomRepository.GetByIdAsync(room.Id);
            if (existingRoom != null) 
            {
                // Handle the error, e.g., throw an exception or return a specific error response
                return ApiResponse<RoomDTO>.CreateErrorResponse($"Room with ID {roomDto.Id} already exists.");
            }
            await _roomRepository.AddRoomAsync(room);
            return ApiResponse<RoomDTO>.CreateSuccessResponse(roomDto, $"Room {roomDto.Id} is added successfully");
        }
    }
}