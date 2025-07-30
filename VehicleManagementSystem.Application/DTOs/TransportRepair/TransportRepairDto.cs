using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.DTOs.TransportRepair {
    public class TransportRepairDto {
        public Guid Id { get; set; }
        public TransportDto Transport { get; set; } = null!;
        public DateTime RepairDate { get; set; }
        public double Cost { get; set; }
        public List<RepairWorkDto> RepairWorks { get; set; } = new();
    }
}
