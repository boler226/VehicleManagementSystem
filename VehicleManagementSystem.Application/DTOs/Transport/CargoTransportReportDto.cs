namespace VehicleManagementSystem.Application.DTOs.Transport;
public class CargoTransportReportDto
{
    public Guid Id { get; set; }
    public string LicensePlate { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public double LoadCapacity { get; set; }
    public int TripsCount { get; set; }
    public double TotalCargoWeight { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
}