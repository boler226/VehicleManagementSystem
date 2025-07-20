namespace VehicleManagementSystem.Application.DTOs {
    public class RouteDto {
        public Guid Id { get; set; }
        public string RouterNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
