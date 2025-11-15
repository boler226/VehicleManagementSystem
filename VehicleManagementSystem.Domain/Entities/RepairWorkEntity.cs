using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities; 
public class RepairWorkEntity {
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid TechnicianId { get; set; }
    public TechnicianEntity Technician { get; set; } = null!;

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid RepairId { get; set; }
    public TransportRepairEntity Repair { get; set; } = null!;

    public string PartName { get; set; } = null!;
    public string WorkDescription { get; set; } = null!;
}
