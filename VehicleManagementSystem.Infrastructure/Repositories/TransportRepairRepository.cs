using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class TransportRepairRepository : ITransportRepairRepository
{
    private readonly IMongoCollection<TransportRepairEntity> _collection;

    public TransportRepairRepository(MongoDbContext context) {
        _collection = context.GetCollection<TransportRepairEntity>("TransportRepairs");
    }

    public async Task<TransportRepairEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TransportRepairEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<List<TransportRepairEntity>> GetByGarageIdAsync(Guid GarageId, CancellationToken cancellationToken)
    {
        return await _collection.Find(t => t.GarageObjectId == GarageId).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TransportRepairEntity repair, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(repair, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(TransportRepairEntity repair, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(r => r.Id == repair.Id, repair, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(TransportRepairEntity repair, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(r => r.Id == repair.Id, cancellationToken: cancellationToken);
    }
}
