namespace Domain.Exceptions;

public class FlightDestinationConflictException : Exception
{
    public FlightDestinationConflictException() { }
    public FlightDestinationConflictException(string message) : base(message) { }
}
