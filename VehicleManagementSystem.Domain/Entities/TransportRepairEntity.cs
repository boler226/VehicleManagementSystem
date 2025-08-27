using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    public class TransportRepairEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid TransportId { get; set; }
        public TransportEntity Transport { get; set; } = null!;

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid? GarageObjectId { get; set; }
        public GarageObjectEntity? GarageObject { get; set; }

        public DateTime RepairDate { get; set; }
        public double Cost { get; set; }
        public ICollection<RepairWorkEntity> RepairWorks { get; set; } = new List<RepairWorkEntity>();
    }
}
