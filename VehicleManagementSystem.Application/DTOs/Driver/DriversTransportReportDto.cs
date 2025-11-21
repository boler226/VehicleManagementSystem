namespace VehicleManagementSystem.Application.DTOs.Driver;
public class DriversTransportReportDto
{
    public int TotalDrivers { get; set; }
    public IEnumerable<DriverItemDto> Drivers { get; set; } = new List<DriverItemDto>();
    public IDictionary<string, int> DriversByModel { get; set; } = new Dictionary<string, int>();
}