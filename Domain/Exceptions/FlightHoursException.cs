namespace Domain.Exceptions;

public class FlightHoursException : Exception
{
    public FlightHoursException() { }
    public FlightHoursException(string message) : base(message) { }
}
