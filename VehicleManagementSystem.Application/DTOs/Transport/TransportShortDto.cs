using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.DTOs.Transport; 
public class TransportShortDto {
    public Guid Id { get; set; }
    public string LicensePlate { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public TransportEnum Type { get; set; }
}
