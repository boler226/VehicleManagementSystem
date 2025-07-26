namespace VehicleManagementSystem.Application.DTOs.Technician {
    public class TechnicianShortDto {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Specialty { get; set; } = null!;
    }
}
