using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.Person;
using VehicleManagementSystem.Application.DTOs.Technician;

namespace VehicleManagementSystem.Application.DTOs.Team; 
public class TeamDto {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public PersonDto? Foreman { get; set; }
    public PersonDto? Master { get; set; }
    public PersonDto? SectionHead { get; set; }
    public PersonDto? WorkshopHead { get; set; }

    public List<DriverShortDto> Drivers { get; set; } = new();
    public List<TechnicianShortDto> Technicians { get; set; } = new();
}
