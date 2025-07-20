using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.DTOs.Transport
{
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
        public List<RouteAssignmentSimpleDto>? RouteAssignments { get; set; }
    }
}
