using VehicleManagementSystem.Application.DTOs.RouteAssignment;

namespace VehicleManagementSystem.Application.DTOs.Route; 
public class RouteDto {
    public Guid Id { get; set; }
    public string RouterNumber { get; set; } = null!;
    public string Description { get; set; } = null!;
    public List<RouteAssignmentShortDto> Assignments { get; set; } = new();
}
