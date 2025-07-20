using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    public class RouteAssignmentEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid TransportId { get; set; }
        public TransportEntity Transport { get; set; } = null!;

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid RouteId { get; set; }
        public RouteEntity Route { get; set; } = null!;

        public DateTime Date { get; set; }
        public int PassengersCarried { get; set; }
    }
}
