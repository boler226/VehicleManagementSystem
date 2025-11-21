using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Enums;

namespace VehicleManagementSystem.Domain.Interfaces.Repositories;

public interface ITransportRepository : IBaseRepository<TransportEntity>
{
    Task<List<TransportEntity>> GetByGarageIdAsync(Guid GarageId,CancellationToken cancellationToken);
    Task<List<TransportEntity>> GetByTypeAsync(TransportEnum type, CancellationToken cancellationToken);
    Task<IEnumerable<TransportEntity>> GetTransportsWithRepairsAsync(
        TransportEnum? category,
        string? brand,
        Guid? transportId,
        DateTime? fromDate,
        DateTime? toDate,
        CancellationToken cancellationToken);
    Task<IEnumerable<TransportEntity>> GetTransportsByPeriodAsync(
        DateTime? fromDate,
        DateTime? toDate,
        CancellationToken cancellationToken);
}