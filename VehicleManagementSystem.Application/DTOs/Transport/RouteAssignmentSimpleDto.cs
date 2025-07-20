namespace VehicleManagementSystem.Application.DTOs.Transport {
    public class RouteAssignmentSimpleDto {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int PassengersCarried { get; set; }
        public Guid RouteId { get; set; }
    }
}
