using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    public class MileageRecordEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid TransportId { get; set; }
        public TransportEntity Transport { get; set; } = null!;

        public DateTime Date { get; set; }
        public double Kilometers { get; set; }
    }
}
