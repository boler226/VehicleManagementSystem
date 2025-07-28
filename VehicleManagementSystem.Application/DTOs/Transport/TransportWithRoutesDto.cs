using VehicleManagementSystem.Application.DTOs.RouteAssignment;

namespace VehicleManagementSystem.Application.DTOs.Transport
{
    public class TransportWithRoutesDto
    {
        public Guid Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public List<RouteAssignmentDto> Routes { get; set; } = new();
    }
}
