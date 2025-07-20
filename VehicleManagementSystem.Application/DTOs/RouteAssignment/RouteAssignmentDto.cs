namespace VehicleManagementSystem.Application.DTOs.RouteAssignment
{
    public class RouteAssignmentDto
    {
        public Guid Id { get; set; }
        public Guid TransportId { get; set; }
        public TransportBasicDto Transport { get; set; } = null!;
        public Guid RouteId { get; set; }
        public RouteDto Route { get; set; } = null!;

        public DateTime Date { get; set; }
        public int PassengersCarried { get; set; }
    }
}
