using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories; 
public class DriverTransportRepository : IDriverTransportRepository
{
    private readonly IMongoCollection<DriverTransportEntity> _collection;

    public DriverTransportRepository(MongoDbContext context) {
        _collection = context.GetCollection<DriverTransportEntity>("DriverTransports");
    }

    public async Task<DriverTransportEntity> GetByIdAsync(Guid driverId, Guid transportId, CancellationToken cancellationToken)
    {
        return await _collection.Find(d => d.DriverId == driverId && d.TransportId == transportId).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<DriverTransportEntity>> GetByDriverIdAsync(Guid driverId, CancellationToken cancellationToken)
    {
        return await _collection.Find(d => d.DriverId == driverId).ToListAsync(cancellationToken);
    }

    public async Task<List<DriverTransportEntity>> GetByTransportIdAsync(Guid transportId, CancellationToken cancellationToken)
    {
        return await _collection.Find(d => d.TransportId == transportId).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DriverTransportEntity driverTransport, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(driverTransport, cancellationToken: cancellationToken);
    }

    public async Task DeleteByDriverIdAsync(Guid driverId, CancellationToken cancellationToken)
    {
        await _collection.DeleteManyAsync(d => d.DriverId == driverId, cancellationToken);
    }

    public async Task DeleteByTransportIdAsync(Guid transportId, CancellationToken cancellationToken)
    {
        await _collection.DeleteManyAsync(d => d.TransportId == transportId, cancellationToken);
    }

    public async Task DeleteByIdAsync(Guid driverId, Guid transportId, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(d => d.DriverId == driverId && d.TransportId == transportId, cancellationToken);
    }
}
