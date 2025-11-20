namespace VehicleManagementSystem.Application.Exceptions;
public class TransportAlreadyAssignedToDriverException : Exception
{
    public TransportAlreadyAssignedToDriverException(Guid driverId, Guid transportId)
        : base($"Transport with Id '{transportId}' is already assigned to Driver with Id '{driverId}'.")
    {
    }
}