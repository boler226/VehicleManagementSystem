using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities; 
public class GarageObjectEntity {
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public ICollection<TransportEntity>? VehiclesStored { get; set; } = new List<TransportEntity>();
}
