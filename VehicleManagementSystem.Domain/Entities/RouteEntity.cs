using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    public class RouteEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string RouterNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public ICollection<RouteAssignmentEntity> Assignments { get; set; } = new List<RouteAssignmentEntity>();
    }
}
