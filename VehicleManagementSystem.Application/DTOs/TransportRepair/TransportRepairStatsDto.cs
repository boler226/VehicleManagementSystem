using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.DTOs.TransportRepair;
public class TransportRepairStatsDto
{
    public Guid Id { get; set; }
    public string LicensePlate { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public TransportEnum Type { get; set; }
    public int RepairCount { get; set; }
    public double TotalCost { get; set; }
}