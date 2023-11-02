namespace Application.DTO.Response;

public class FlightDestinationResponse
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public decimal TicketPrice { get; set; }
    public FlightDestinationAircraft Aircraft { get; set; }

}
