using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;

namespace MedicalStaff.Application.Handlers.Rooms
{
    public class GetAllRoomsHandler(IRoomRepository _roomRepository) : IRequestHandler<GetAllRoomsRequest, ApiResponse<IEnumerable<RoomDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<RoomDTO>>> Handle(GetAllRoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.GetAllAsync();
            return ApiResponse<IEnumerable<RoomDTO>>.CreateSuccessResponse(rooms.Adapt<IEnumerable<RoomDTO>>(), "Rooms retrieved successfuly.");
        }
    }
}
