using Microsoft.AspNetCore.Mvc;
using MedicalStaff.Application.DTOs;
using MedicalStaff.Application.Requests.DepartmentRequests;
using MediatR;

namespace MedicalStaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartments()
        {
            var request = new GetAllDepartmentsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/Department/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartment(int id)
        {
            var request = new GetDepartmentByIdRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // GET: api/Department/Cardiology
        [HttpGet("/{departmentName}/Rooms")]
        public async Task<ActionResult<DepartmentDTO>> RoomsInDepartment(string departmentName)
        {
            var request = new DisplayRoomsInDepartmentRequest(departmentName);
            var response = await _mediator.Send(request);

            return Ok(response);
        }


        // PUT: api/Department/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentDTO department)
        {
            if (id != department.Id)
            {
                return BadRequest("Department ID mismatch.");
            }

            var request = new UpdateDepartmentRequest(department);
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound("Department not found.");
            }

            return Ok(response);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<ActionResult<DepartmentDTO>> PostDepartment(DepartmentDTO department)
        {
            var request = new AddDepartmentRequest(department);
            var response = await _mediator.Send(request);
            return Ok(response);

        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var request = new DeleteDepartmentRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
