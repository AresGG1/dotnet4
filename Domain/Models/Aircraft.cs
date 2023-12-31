using Bogus.DataSets;
using Domain.Exceptions;

namespace Domain.Models;

public class Aircraft
{
    private const int MinDifference = 4;
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int FlightHours { get; set; }
    public List<FlightDestination> FlightDestinations { get; }

    public void AddFlightDestination(FlightDestination flightDestination)
    {
        bool hasConflict = 
            FlightDestinations.Any(fd => CheckTimeConflict(flightDestination, fd));
        
        if (hasConflict)
        {
            throw new FlightDestinationConflictException(
                "Time conflict, there must be minimum 4 hours between flights"
                );
        }
        
        if (CheckFlightHours())
        {
            throw new FlightHoursException("This aircraft does not allow more flights");
        }
        
        FlightDestinations.Add(flightDestination);
    }
    public void DeleteDestinationIfExists(int destinationId)
    {
        var destination = FlightDestinations.Find(fd => fd.Id == destinationId);


        FlightDestinations.Remove(destination);
    }
    private bool CheckTimeConflict(FlightDestination newDestination, FlightDestination currentDestination)
    {
        var difference = newDestination.Start - currentDestination.Start;
        
        return Math.Abs(difference.TotalHours) < MinDifference;
    }
    
    private bool CheckFlightHours()
    {
        return this.FlightHours > 2000;
    }
    
    public void RemoveFlightDestination(FlightDestination flightDestination)
    {
        FlightDestinations.Remove(flightDestination);
    }
}
