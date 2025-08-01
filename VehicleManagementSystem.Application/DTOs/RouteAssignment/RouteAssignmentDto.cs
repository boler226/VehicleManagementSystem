using VehicleManagementSystem.Application.DTOs.Route;
using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.DTOs.RouteAssignment {
    public class RouteAssignmentDto {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int PassengersCarried { get; set; }

        public TransportShortDto Transport { get; set; } = null!;
        public RouteShortDto Route { get; set; } = null!;
    }
}
