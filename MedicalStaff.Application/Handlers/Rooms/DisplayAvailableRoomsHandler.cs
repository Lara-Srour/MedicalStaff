using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;


namespace MedicalStaff.Application.Rooms
{
    public class DisplayAvailableRoomsHandler : IRequestHandler<DisplayAvailableRoomsRequest, ApiResponse<IEnumerable<RoomDTO>>>
    {
        private readonly IRoomRepository _roomRepository;

        public DisplayAvailableRoomsHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ApiResponse<IEnumerable<RoomDTO>>> Handle(DisplayAvailableRoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.DisplayAvailableRoomsAsync(request.DepartmentName);
            var roomDtos = rooms.Adapt<IEnumerable<RoomDTO>>();
            if (roomDtos == null || !roomDtos.Any())
            {
                return ApiResponse<IEnumerable<RoomDTO>>.CreateErrorResponse($"No Available rooms found in Department {request.DepartmentName}");
            }
         
            return ApiResponse<IEnumerable<RoomDTO>>.CreateSuccessResponse(roomDtos, $"Available Rooms in {request.DepartmentName} Department are retrieved successfully");
        }
    }       
}