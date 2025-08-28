using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace VehicleManagementSystem.Domain.Entities {
    public class TeamEntity {
        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid? ForemanId { get; set; }
        public PersonEntity? Foreman { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid? MasterId { get; set; }
        public PersonEntity? Master { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid? SectionHeadId { get; set; } 
        public PersonEntity? SectionHead { get; set; }

        [BsonGuidRepresentation(GuidRepresentation.Standard)]
        public Guid? WorkshopHeadId { get; set; }
        public PersonEntity? WorkshopHead { get; set; }

        public ICollection<DriverEntity>? Drivers { get; set; } = new List<DriverEntity>();
        public ICollection<TechnicianEntity> Technicians { get; set; } = new List<TechnicianEntity>();
    }
}
