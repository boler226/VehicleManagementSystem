namespace VehicleManagementSystem.Application.DTOs.RepairWork;
public class RepairWorkItemDto
{
    public Guid RepairId { get; set; }
    public DateTime RepairDate { get; set; }
    public string PartName { get; set; } = null!;
    public string WorkDescription { get; set; } = null!;
    public Guid TransportId { get; set; }
    public string LicensePlate { get; set; } = null!;
    public double Cost { get; set; }
}