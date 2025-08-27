namespace VehicleManagementSystem.Application.DTOs.MileageRecord {
    public class MileageRecordShortDto {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public double Kilometers { get; set; }
    }
}