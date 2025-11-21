namespace VehicleManagementSystem.Application.DTOs.RouteAssignment;
public class RoutePassengerDistributionDto
{
    public Guid RouteId { get; set; }
    public string RouteNumber { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int TotalPassengers { get; set; }
}