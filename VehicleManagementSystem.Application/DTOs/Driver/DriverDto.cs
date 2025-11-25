using VehicleManagementSystem.Application.DTOs.Team;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.DTOs.Driver; 
public class DriverDto {
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public TeamShortDto Team { get; set; } = null!;
    public List<TransportShortDto>? Vehicles { get; set; } = new();
}
