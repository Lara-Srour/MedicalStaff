using Microsoft.AspNetCore.Mvc;
using MedicalStaff.Application.DTOs;
using static MedicalStaff.Application.Requests.PatientRequests;
using MediatR;

namespace MedicalStaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatients()
        {
            var request = new GetAllPatientsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/Patient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatient(int id)
        {
            var request = new GetPatientByIdRequest(id);
            var response = await _mediator.Send(request); 

            return Ok(response);
        }

        // PUT: api/Patient/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientDTO patient)
        {
            if (id != patient.Id) 
            {
                return BadRequest("Patient ID mismatch.");
            }

            var request = new UpdatePatientRequest(patient);
            var response = await _mediator.Send(request);

            if (response == null) 
            {
                return NotFound("Patient not found.");
            }

            return Ok(response);
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<ActionResult<PatientDTO>> PostPatient(PatientDTO patient)
        {
            var request = new AddPatientRequest(patient);
            var response = await _mediator.Send(request);   
            return Ok(response);

        }

        // DELETE: api/Patient/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var request = new DeletePatientRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

       
    }
}
