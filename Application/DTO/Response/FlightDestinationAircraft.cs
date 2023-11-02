namespace Application.DTO.Response;

public class FlightDestinationAircraft
{
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int FlightHours { get; set; }
}