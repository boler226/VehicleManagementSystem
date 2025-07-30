namespace VehicleManagementSystem.Application.DTOs.RepairWork {
    public class RepairWorkShortDto {
        public Guid Id { get; set; }
        public string PartName { get; set; } = null!;
        public string WorkDescription { get; set; } = null!;
    }
}
