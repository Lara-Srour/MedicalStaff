using Mapster;
using MediatR;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Domain;
using static MedicalStaff.Application.Requests.RoomRequests;


namespace MedicalStaff.Application.Handlers.Rooms
{
    public class DisplayAvailableRoomsHandler(IRoomRepository _roomRepository) : IRequestHandler<DisplayAvailableRoomsRequest, ApiResponse<IEnumerable<RoomDTO>>>
    {
        public async Task<ApiResponse<IEnumerable<RoomDTO>>> Handle(DisplayAvailableRoomsRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _roomRepository.DisplayAvailableRoomsAsync(request.DepartmentName);
            
            if (rooms == null || !rooms.Any())
            {
                return ApiResponse<IEnumerable<RoomDTO>>.CreateErrorResponse($"No Available rooms found in Department {request.DepartmentName}");
            }
         
            return ApiResponse<IEnumerable<RoomDTO>>.CreateSuccessResponse(rooms.Adapt<IEnumerable<RoomDTO>>(), $"Available Rooms in {request.DepartmentName} Department are retrieved successfully");
        }
    }       
}