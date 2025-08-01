using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Application.DTOs.TransportRepair;

namespace VehicleManagementSystem.Application.DTOs.RepairWork {
    public class RepairWorkDto {
        public Guid Id { get; set; }
        public string PartName { get; set; } = null!;
        public string WorkDescription { get; set; } = null!;
        public TechnicianShortDto Technician { get; set; } = null!;
        public TransportRepairShortDto Repair { get; set; } = null!;
    }
}
