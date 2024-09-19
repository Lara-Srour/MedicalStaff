using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;

namespace MedicalStaff.Application.Handlers.Rooms
{
    public class GetRoomByIdHandler : IRequestHandler<GetRoomByIdRequest, ApiResponse<RoomDTO>>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomByIdHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ApiResponse<RoomDTO>> Handle(GetRoomByIdRequest request, CancellationToken cancellationToken)
        {
            // Check if the room exists
            var room = await _roomRepository.GetByIdAsync(request.Id);
            var roomDto = room.Adapt<RoomDTO>();
            if (roomDto == null)
            {
                return ApiResponse<RoomDTO>.CreateErrorResponse($"Room with ID {request.Id} does not exist.");
            }
            
            return ApiResponse<RoomDTO>.CreateSuccessResponse(roomDto, $"Room {roomDto.Id} is retrieved successfully.");
        }
    }
}
