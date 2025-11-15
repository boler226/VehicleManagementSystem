using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Application.DTOs.Team;

namespace VehicleManagementSystem.Application.DTOs.Technician; 
public class TechnicianDto {
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public TeamShortDto Team { get; set; } = null!;
    public List<RepairWorkShortDto> RepairWorks { get; set; } = new();
}
