namespace VehicleManagementSystem.Application.DTOs.GarageObject; 
public class GarageObjectShortDto {
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
}
