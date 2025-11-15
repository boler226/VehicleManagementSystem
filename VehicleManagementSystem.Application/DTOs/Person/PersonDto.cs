namespace VehicleManagementSystem.Application.DTOs.Person; 
public class PersonDto {
    public Guid Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Position { get; set; } = null!;
}
