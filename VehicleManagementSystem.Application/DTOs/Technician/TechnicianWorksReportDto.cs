using VehicleManagementSystem.Application.DTOs.RepairWork;

namespace VehicleManagementSystem.Application.DTOs.Technician;
public class TechnicianWorksReportDto
{
    public Guid TechnicianId { get; set; }
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public int TotalWorks { get; set; }
    public double TotalCost { get; set; }
    public IEnumerable<RepairWorkItemDto> Works { get; set; } = new List<RepairWorkItemDto>();

    public int VehicleWorksCount { get; set; }
    public double VehicleWorksCost { get; set; }
}