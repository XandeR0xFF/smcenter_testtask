using Microsoft.AspNetCore.Mvc;
using smcenter_testtask.Application.Requests;
using smcenter_testtask.Application.Responses;
using smcenter_testtask.Application.Services;

namespace smcenter_testtask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController(PatientService patientService) : ControllerBase
{
    private readonly PatientService _patientService = patientService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PatientResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    async public Task<ActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? orderBy)
    {
        try
        {
            var patients = await _patientService.GetAll(page, pageSize, orderBy);
            return Ok(patients);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(PatientForEditResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    async public Task<ActionResult> Get(long id)
    {
        try
        {
            var patient = await _patientService.GetForEditByIdAsync(id);
            return Ok(patient);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] CreatePatientRequest request)
    {
        try
        {
            await _patientService.Create(request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Put(long id, [FromBody] UpdatePatientRequest request)
    {
        try
        {
            await _patientService.Update(id, request);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(long id)
    {
        try
        {
            await _patientService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
