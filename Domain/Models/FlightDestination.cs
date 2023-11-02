namespace Domain.Models;

public class FlightDestination
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public int AircraftId { get; set; }
    public decimal TicketPrice { get; set; }
    public Aircraft Aircraft { get; set; }
    
}
