using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Domain.Entities
{
    public class TransportEntity
    {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string LicensePlate { get; set; } = null!;
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public TransportEnum Type { get; set; }
        public int? Capacity { get; set; } // тільки для пасажирського транспорту
        public double? LoadCapacity { get; set; } // тільки для вантажного
        public bool IsWrittenOff { get; set; }
        public DateTime? WriteOffDate { get; set; }

        public ICollection<DriverTransportEntity> Drivers { get; set; } = new List<DriverTransportEntity>();
        public ICollection<RouteAssignmentEntity> RouteAssignments { get; set; } = new List<RouteAssignmentEntity>();
        public ICollection<TransportRepairEntity> Repairs { get; set; } = new List<TransportRepairEntity>();
        public ICollection<MileageRecordEntity> Mileages { get; set; } = new List<MileageRecordEntity>();
    }
}
