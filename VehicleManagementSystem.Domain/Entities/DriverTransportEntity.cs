using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    [BsonIgnoreExtraElements]
    public class DriverTransportEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid DriverId { get; set; }
        public DriverEntity Driver { get; set; } = null!;

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid TransportId { get; set; }
        public TransportEntity Transport { get; set; } = null!;
    }
}
