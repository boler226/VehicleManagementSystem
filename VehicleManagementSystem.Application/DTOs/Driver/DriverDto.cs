namespace VehicleManagementSystem.Application.DTOs.Driver {
    public class DriverDto {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
        public Guid TeamId { get; set; }

        public string? TeamName { get; set; }
        public int VehicleCount { get; set; }
    }

}
