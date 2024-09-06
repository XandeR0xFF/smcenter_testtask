using Microsoft.AspNetCore.Mvc;
using smcenter_testtask.Application.Requests;
using smcenter_testtask.Application.Responses;
using smcenter_testtask.Application.Services;


namespace smcenter_testtask.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController(DoctorService doctorService) : ControllerBase
{
    private DoctorService _doctorService = doctorService;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DoctorResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    async public Task<ActionResult> Get([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? orderBy)
    {
        try
        {
            IEnumerable<DoctorResponse> doctors = await _doctorService.GetAll(page, pageSize, orderBy);
            return Ok(doctors);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(DoctorForEditResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    async public Task<ActionResult> Get(long id)
    {
        try
        {
            DoctorForEditResponse doctor = await _doctorService.GetForEditByIdAsync(id);
            return Ok(doctor);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] CreateDoctorRequest request)
    {
        try
        {
            await _doctorService.Create(request);
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
    public async Task<ActionResult> Put(long id, [FromBody]UpdateDoctorRequest request)
    {
        try
        {
            await _doctorService.Update(id, request);
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
            await _doctorService.Delete(id);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
