using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class RouteRepository : IRouteRepository
{
    private readonly IMongoCollection<RouteEntity> _collection;

    public RouteRepository(MongoDbContext context) {
        _collection = context.GetCollection<RouteEntity>("Routes");
    }

    public async Task<RouteEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<RouteEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(RouteEntity route, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(route, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(RouteEntity route, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(r => r.Id == route.Id, route, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(RouteEntity route, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(r => r.Id == route.Id, cancellationToken: cancellationToken);
    }
}