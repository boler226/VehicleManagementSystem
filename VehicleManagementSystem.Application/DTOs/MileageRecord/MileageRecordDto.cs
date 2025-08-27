using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.DTOs.MileageRecord {
    public class MileageRecordDto {
        public Guid Id { get; set; }
        public TransportShortDto Transport { get; set; } = new();
        public DateTime Date { get; set; }
        public double Kilometers { get; set; }
    }
}
