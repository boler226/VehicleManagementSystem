namespace VehicleManagementSystem.Application.DTOs.Route; 
public class RouteShortDto {
    public Guid Id { get; set; }
    public string RouteNumber { get; set; } = null!;
    public string Description { get; set; } = null!;
}
