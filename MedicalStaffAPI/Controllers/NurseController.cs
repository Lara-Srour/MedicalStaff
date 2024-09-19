using Microsoft.AspNetCore.Mvc;
using MedicalStaff.Application.DTOs;
using static MedicalStaff.Application.Requests.NurseRequests;
using MediatR;

namespace MedicalStaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NurseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Nurse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseDTO>>> GetNurses()
        {
            var request = new GetAllNursesRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/Nurse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NurseDTO>> GetNurse(int id)
        {
            var request = new GetNurseByIdRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // GET: api/Nurse/Cardiology
        [HttpGet("/{departmentName}")]
        public async Task<ActionResult<NurseDTO>> GetNursesInDepartment(string departmentName)
        {
            var request = new GetNursesInDepartmentRequest(departmentName);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // PUT: api/Nurse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurse(int id, NurseDTO nurse)
        {
            if (id != nurse.Id)
            {
                return BadRequest("Nurse ID mismatch.");
            }

            var request = new UpdateNurseRequest(nurse);
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound("Nurse not found.");
            }

            return Ok(response);
        }

        // POST: api/Nurse
        [HttpPost]
        public async Task<ActionResult<NurseDTO>> PostNurse(NurseDTO nurse)
        {
            var request = new AddNurseRequest(nurse);
            var response = await _mediator.Send(request);
            return Ok(response);

        }

        // DELETE: api/Nurse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            var request = new DeleteNurseRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
