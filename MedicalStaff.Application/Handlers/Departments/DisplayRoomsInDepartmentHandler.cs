using MediatR;
using Mapster;
using MedicalStaff.Domain;
using MedicalStaff.Application.Interfaces;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Resposne;
using MedicalStaff.Application.Requests.DepartmentRequests;
using System.Collections.Generic;


namespace MedicalStaff.Application.Departments
{
    public class DisplayRoomsInDepartmentHandler : IRequestHandler<DisplayRoomsInDepartmentRequest, ApiResponse<IEnumerable<RoomDTO>>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DisplayRoomsInDepartmentHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<ApiResponse<IEnumerable<RoomDTO>>> Handle(DisplayRoomsInDepartmentRequest request, CancellationToken cancellationToken)
        {
            var rooms = await _departmentRepository.DisplayRoomsInDepartmentAsync(request.DepartmentName);
            var roomDtos = rooms.Adapt<IEnumerable<RoomDTO>>();
            // Check if any rooms were found
            if (rooms == null || !rooms.Any())
            {
                return ApiResponse<IEnumerable<RoomDTO>>.CreateErrorResponse($"No rooms found in the {request.DepartmentName} department.");
            }

            // Return a success response with the list of RoomDTOs
            return ApiResponse<IEnumerable<RoomDTO>>.CreateSuccessResponse(roomDtos, $"List of rooms in {request.DepartmentName} department is successfully retrieved.");

        }
    }       
}