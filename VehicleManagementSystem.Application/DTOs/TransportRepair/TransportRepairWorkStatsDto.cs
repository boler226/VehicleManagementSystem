namespace VehicleManagementSystem.Application.DTOs.TransportRepair;
internal class TransportRepairWorkStatsDto
{
    public Guid Id { get; set; }
    public string LicensePlate { get; set; } = null!;
    public double Cost { get; set; }
}