using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;

namespace MedicalStaff.Application.Handlers.Rooms
{
    public class GetAllRoomsHandler : IRequestHandler<GetAllRoomsRequest, ApiResponse<IEnumerable<RoomDTO>>>
    {
        private readonly IRoomRepository _roomRepository;

        public GetAllRoomsHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ApiResponse<IEnumerable<RoomDTO>>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            var roomDtos = rooms.Adapt<IEnumerable<RoomDTO>>();
            return ApiResponse<IEnumerable<RoomDTO>>.CreateSuccessResponse(roomDtos, "Rooms retrieved successfuly.");
        }
    }
}
