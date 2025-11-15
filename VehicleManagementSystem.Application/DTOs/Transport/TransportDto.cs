using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Application.DTOs.GarageObject;
using VehicleManagementSystem.Application.DTOs.MileageRecord;
using VehicleManagementSystem.Application.DTOs.RouteAssignment;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.DTOs.Transport;

public class TransportDto
{
    public Guid Id { get; set; }
    public string LicensePlate { get; set; } = null!;
    public string Brand { get; set; } = null!;
    public string Model { get; set; } = null!;
    public TransportEnum Type { get; set; }
    public int? Capacity { get; set; }
    public double? LoadCapacity { get; set; }
    public bool IsWrittenOff { get; set; }
    public DateTime? WriteOffDate { get; set; }

    public GarageObjectShortDto? GarageObject { get; set; }

    public List<DriverShortDto>? Drivers { get; set; } = new();
    public List<RouteAssignmentShortDto>? Assignments { get; set; } = new();
    public List<MileageRecordShortDto>? Mileages { get; set; } = new();
}
