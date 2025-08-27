using VehicleManagementSystem.Application.DTOs.Transport;

namespace VehicleManagementSystem.Application.DTOs.GarageObject {
    public class GarageObjectDto {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public List<TransportShortDto> VehiclesStored { get; set; } = new();
    }
}
