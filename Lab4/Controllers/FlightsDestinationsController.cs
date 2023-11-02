using Application.Commands.FlightDestinations;
using Application.DTO.Response;
using Application.Queries.Aircrafts;
using Application.Queries.FlightDestinations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers;


[ApiController]
[Route("api/[controller]")]
public class FlightsDestinationsController : Controller
{
    private readonly IMediator _mediator;

    public FlightsDestinationsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<FlightDestinationResponse>>> GetAsync()
    {
        var flightDestinations = 
            await _mediator.Send(new GetFlightDestinationsQuery());
       
        return Ok(flightDestinations);
    }   
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<FlightDestinationResponse>> GetByIdAsync([FromRoute] int id)
    {
        var flightDestination = 
            await _mediator.Send(new GetFlightDestinationByIdQuery(id));
       
        return Ok(flightDestination);
    }   
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> InsertAsync([FromBody] CreateFlightDestinationCommand flightDestinationCommand)
    {
        var flightDestination = await _mediator.Send(flightDestinationCommand);
    
        return CreatedAtAction("GetById", new { id = flightDestination.Id }, flightDestination);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateAsync(
        [FromRoute] int id,
        [FromBody] UpdateFlightDestinationCommand flightDestinationCommand)
    {
        if (flightDestinationCommand.Id != id)
        {
            return BadRequest("Id url param and request body id param do not match");
        }
        
        flightDestinationCommand.Id = id;
        await _mediator.Send(flightDestinationCommand);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        await _mediator.Send(new DeleteFlightDestinationCommand(id));        
        return NoContent();
    }
}
