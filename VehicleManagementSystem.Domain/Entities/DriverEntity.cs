using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VehicleManagementSystem.Domain.Entities;

public class DriverEntity
{
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public ICollection<DriverTransportEntity>? Vechicles { get; set; } = new List<DriverTransportEntity>();

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid TeamId { get; set; }
    public TeamEntity Team { get; set; } = null!;
}
