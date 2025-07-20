using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    public class PersonEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
