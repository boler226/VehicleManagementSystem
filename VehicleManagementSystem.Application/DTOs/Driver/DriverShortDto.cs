namespace VehicleManagementSystem.Application.DTOs.Driver; 
public class DriverShortDto {
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string LicenseNumber { get; set; } = null!;
}
