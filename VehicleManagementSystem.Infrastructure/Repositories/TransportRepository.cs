using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Enums;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;

public class TransportRepository : ITransportRepository
{
    private readonly IMongoCollection<TransportEntity> _collection;

    public TransportRepository(MongoDbContext context) {
        _collection = context.GetCollection<TransportEntity>("Transports");
    }

    public async Task<TransportEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(t => t.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TransportEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<List<TransportEntity>> GetByGarageIdAsync(Guid GarageId, CancellationToken cancellationToken)
    {
        return await _collection.Find(t => t.GarageObjectId == GarageId).ToListAsync(cancellationToken);
    }

    public async Task<List<TransportEntity>> GetByTypeAsync(TransportEnum type, CancellationToken cancellationToken)
    {
        return await _collection.Find(t => t.Type == type).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TransportEntity>> GetTransportsWithRepairsAsync(
        TransportEnum? category,
        string? brand,
        Guid? transportId,
        DateTime? fromDate,
        DateTime? toDate,
        CancellationToken cancellationToken)
    {
        var filterBuilder = Builders<TransportEntity>.Filter;
        var filter = FilterDefinition<TransportEntity>.Empty;

        if (category.HasValue)
            filter &= filterBuilder.Eq(x => x.Type, category.Value);

        if (!string.IsNullOrEmpty(brand))
            filter &= filterBuilder.Eq(x => x.Brand, brand);

        if (transportId.HasValue)
            filter &= filterBuilder.Eq(x => x.Id, transportId.Value);

        var transports = await _collection.Find(filter).ToListAsync(cancellationToken);

        foreach (var transport in transports)
        {
            transport.Repairs = transport.Repairs
                .Where(r => (!fromDate.HasValue || r.RepairDate >= fromDate.Value) &&
                            (!toDate.HasValue || r.RepairDate <= toDate.Value))
                .ToList();
        }

        return transports;
    }

    public async Task<IEnumerable<TransportEntity>> GetTransportsByPeriodAsync(
        DateTime? fromDate,
        DateTime? toDate,
        CancellationToken cancellationToken)
    {
        var filterBuilder = Builders<TransportEntity>.Filter;
        var filter = FilterDefinition<TransportEntity>.Empty;

        if (fromDate.HasValue)
            filter &= filterBuilder.Or(
                filterBuilder.Gte(x => x.WriteOffDate, fromDate.Value),
                filterBuilder.Eq(x => x.WriteOffDate, null) // ще не списаний
            );

        if (toDate.HasValue)
            filter &= filterBuilder.Or(
                filterBuilder.Lte(x => x.WriteOffDate, toDate.Value),
                filterBuilder.Eq(x => x.WriteOffDate, null)
            );

        return await _collection.Find(filter).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(TransportEntity transport, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(transport, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(TransportEntity transport, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(t => t.Id == transport.Id, transport, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(TransportEntity transport, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(t => t.Id == transport.Id, cancellationToken: cancellationToken);
    }
}