using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class RouteAssignmentRepository : IRouteAssignmentRepository
{
    private readonly IMongoCollection<RouteAssignmentEntity> _collection;

    public RouteAssignmentRepository(MongoDbContext context) {
        _collection = context.GetCollection<RouteAssignmentEntity>("RouteAssignments");
    }

    public async Task<RouteAssignmentEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<RouteAssignmentEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<List<RouteAssignmentEntity>> GetByRouteIdAsync(Guid routeId, CancellationToken cancellationToken)
    {
        return await _collection.Find(r => r.RouteId == routeId).ToListAsync(cancellationToken);
    }

    public async Task<List<RouteAssignmentEntity>> GetByTransportIdAsync(Guid trasnportId, CancellationToken cancellationToken)
    {
        return await _collection.Find(r => r.TransportId == trasnportId).ToListAsync(cancellationToken);
    }

    public async Task<List<RouteAssignmentEntity>> GetByTransportAndPeriodAsync(
        Guid transportId,
        DateTime start,
        DateTime end,
        CancellationToken cancellationToken)
    {
        var filter = Builders<RouteAssignmentEntity>.Filter.And(
            Builders<RouteAssignmentEntity>.Filter.Eq(x => x.TransportId, transportId),
            Builders<RouteAssignmentEntity>.Filter.Gte(x => x.Date, start),
            Builders<RouteAssignmentEntity>.Filter.Lte(x => x.Date, end)
        );

        return await _collection.Find(filter).ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<RouteAssignmentEntity>> GetAssignmentsAsync(
        DateTime? fromDate,
        DateTime? toDate,
        CancellationToken cancellationToken)
    {
        var filterBuilder = Builders<RouteAssignmentEntity>.Filter;
        var filter = FilterDefinition<RouteAssignmentEntity>.Empty;

        if (fromDate.HasValue)
            filter &= filterBuilder.Gte(x => x.Date, fromDate.Value);

        if (toDate.HasValue)
            filter &= filterBuilder.Lte(x => x.Date, toDate.Value);

        return await _collection.Find(filter).ToListAsync(cancellationToken);
    } 

    public async Task AddAsync(RouteAssignmentEntity route, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(route, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(RouteAssignmentEntity route, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(r => r.Id == route.Id, route, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(RouteAssignmentEntity route, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(r => r.Id == route.Id, cancellationToken: cancellationToken);
    }
}