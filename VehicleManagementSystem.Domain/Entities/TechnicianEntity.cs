using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities; 
public class TechnicianEntity {
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid TeamId { get; set; }
    public TeamEntity Team { get; set; } = null!;
    public ICollection<RepairWorkEntity>? RepairWorks { get; set; } = new List<RepairWorkEntity>();
}
