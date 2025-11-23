using MongoDB.Bson.Serialization.Attributes;

namespace VehicleManagementSystem.Domain.Entities.Identity;
public class RegistrationRequest
{
    [BsonId]
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}