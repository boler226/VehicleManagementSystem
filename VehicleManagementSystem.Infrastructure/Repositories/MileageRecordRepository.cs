using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class MileageRecordRepository : IMileageRecordRepository {
    private readonly IMongoCollection<MileageRecordEntity> _collection;

    public MileageRecordRepository(MongoDbContext context) {
        _collection = context.GetCollection<MileageRecordEntity>("Mileages");
    }

    public async Task<MileageRecordEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(m => m.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<MileageRecordEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<List<MileageRecordEntity>> GetByTransportIdAsync(Guid transportId, CancellationToken cancellationToken)
    {
        return await _collection.Find(m => m.TransportId == transportId).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(MileageRecordEntity mileageRecord, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(mileageRecord, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(MileageRecordEntity mileageRecord, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(p => p.Id == mileageRecord.Id, mileageRecord, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(MileageRecordEntity mileageRecord, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(p => p.Id == mileageRecord.Id, cancellationToken: cancellationToken);
    }
}