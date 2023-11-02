using Application.Commands.Aircrafts;
using Application.DTO.Response;
using Application.Queries;
using Application.Queries.Aircrafts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AircraftsController : Controller
{
    private readonly IMediator _mediator;

    public AircraftsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<AircraftResponse>>> GetAsync()
    {
        var aircrafts = await _mediator.Send(new GetAircraftsQuery());        
        
        return Ok(aircrafts);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<AircraftResponse>> GetByIdAsync([FromRoute] int id)
    {
        var res = await _mediator.Send(new GetAircraftByIdQuery(id));

        return Ok(res);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] CreateAircraftCommand aircraftCommand)
    {
        var aircraft = await _mediator.Send(aircraftCommand);
    
        return CreatedAtAction("GetById", new { id = aircraft.Id }, aircraft);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateAircraftCommand aircraftCommand)
    {
        if (aircraftCommand.Id != id)
        {
            return BadRequest("Id url param and request body id param do not match");
        }
        
        aircraftCommand.Id = id;
        await _mediator.Send(aircraftCommand);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteAircraftCommand(id));        
        return NoContent();
    }
}
