namespace VehicleManagementSystem.Application.DTOs.Driver;
public class DriverItemDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public IEnumerable<string> TransportModels { get; set; } = new List<string>();
}