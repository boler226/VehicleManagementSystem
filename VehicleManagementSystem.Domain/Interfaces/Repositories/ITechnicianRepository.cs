using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories; 
public interface ITechnicianRepository : IBaseRepository<TechnicianEntity> 
{
    Task<TechnicianEntity?> GetByIdWithWorksAsync(Guid technicianId, DateTime fromDate, DateTime toDate, CancellationToken cancellationToken);
}