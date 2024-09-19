using Microsoft.AspNetCore.Mvc;
using MedicalStaff.Application.DTOs;
using static MedicalStaff.Application.Requests.RoomRequests;
using MediatR;

namespace MedicalStaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRooms()
        {
            var request = new GetAllRoomsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDTO>> GetRoom(int id)
        {
            var request = new GetRoomByIdRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // GET: api/Room/Cardiology/Available Rooms
        [HttpGet("{departmentName}/Available Rooms")]
        public async Task<ActionResult<RoomDTO>> GetAvailableRooms(string departmentName)
        {
            var request = new DisplayAvailableRoomsRequest(departmentName);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // PUT: api/Room/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, RoomDTO room)
        {
            if (id != room.Id)
            {
                return BadRequest("Room ID mismatch.");
            }

            var request = new UpdateRoomRequest(room);
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound("Room not found.");
            }

            return Ok(response);
        }

        // POST: api/Room
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> PostRoom(RoomDTO room)
        {
            var request = new AddRoomRequest(room);
            var response = await _mediator.Send(request);
            return Ok(response);

        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var request = new DeleteRoomRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
