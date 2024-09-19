using Microsoft.AspNetCore.Mvc;
using MedicalStaff.Application.DTOs;
using static MedicalStaff.Application.Requests.DoctorRequests;
using MediatR;

namespace MedicalStaffAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctors()
        {
            var request = new GetAllDoctorsRequest();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDTO>> GetDoctor(int id)
        {
            var request = new GetDoctorByIdRequest(id);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // GET: api/Doctor/cardiologist
        [HttpGet("{specialty}/Doctors")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorsBySpecialty(string specialty)
        {
            var request = new GetDoctorsBySpecialtyRequest(specialty);
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        // GET: api/Doctor/5/patients
        [HttpGet("{doctorId}/patients")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorPatients(int doctorId)
        {
            var request = new GetDoctorPatientsRequest(doctorId);
            var response = await _mediator.Send(request);

            return Ok(response);
        }


        // PUT: api/Doctor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, DoctorDTO doctora)
        {
            if (id != doctora.Id)
            {
                return BadRequest("Doctor ID mismatch.");
            }

            var request = new UpdateDoctorRequest(doctora);
            var response = await _mediator.Send(request);

            if (response == null)
            {
                return NotFound("Doctor not found.");
            }

            return Ok(response);
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<ActionResult<DoctorDTO>> PostDoctor(DoctorDTO doctor)
        {
            var request = new AddDoctorRequest(doctor);
            var response = await _mediator.Send(request);
            return Ok(response);

        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var request = new DeleteDoctorRequest(id);
            var response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}
