using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.Technician;

namespace VehicleManagementSystem.Application.DTOs.Team;
public class SubordinatesReportDto
{
    public Guid LeaderId { get; set; }
    public string LeaderName { get; set; } = null!;
    public string LeaderPosition { get; set; } = null!;
    public IEnumerable<DriverShortDto> Drivers { get; set; } = new List<DriverShortDto>();
    public IEnumerable<TechnicianShortDto> Technicians { get; set; } = new List<TechnicianShortDto>();
}