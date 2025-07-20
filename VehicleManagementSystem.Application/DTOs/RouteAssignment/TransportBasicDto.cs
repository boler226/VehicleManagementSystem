using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Application.DTOs.RouteAssignment {
    public class TransportBasicDto {
        public Guid Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public TransportEnum Type { get; set; }
    }

}
