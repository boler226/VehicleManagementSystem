using AspNetCore.Identity.MongoDbCore.Models;

namespace VehicleManagementSystem.Domain.Entities.Identity; 
public class UserEntity : MongoIdentityUser<Guid> {
    public string FullName { get; set; } = null!;
    public string Role { get; set; } = null!;
}