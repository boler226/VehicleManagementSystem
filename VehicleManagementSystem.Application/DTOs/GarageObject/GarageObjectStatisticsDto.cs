using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.DTOs.GarageObject;
public class GarageObjectStatisticsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public int TotalVehicles { get; set; }
    public Dictionary<TransportEnum, int> VehiclesByCategory { get; set; } = new();
}