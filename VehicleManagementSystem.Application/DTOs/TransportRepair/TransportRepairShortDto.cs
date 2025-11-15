using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.DTOs.TransportRepair; 
public class TransportRepairShortDto {
    public Guid Id { get; set; }
    public DateTime RepairDate { get; set; }
    public double Cost { get; set; }
}
