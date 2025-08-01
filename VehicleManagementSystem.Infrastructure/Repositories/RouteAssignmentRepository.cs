using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories {
    public class RouteAssignmentRepository : IRouteAssignmentRepository {
        private readonly IMongoCollection<RouteAssignmentEntity> _collection;

        public RouteAssignmentRepository(MongoDbContext context) {
            _collection = context.GetCollection<RouteAssignmentEntity>("RouteAssignments");
        }

        public async Task<RouteAssignmentEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
           await _collection.Find(r => r.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<RouteAssignmentEntity>?> GetAllAsync(CancellationToken cancellationToken) =>
            await _collection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task<List<RouteAssignmentEntity>?> GetAllByRouteIdAsync(Guid routeId, CancellationToken cancellationToken) =>
            await _collection.Find(r => r.RouteId == routeId).ToListAsync(cancellationToken);

        public async Task<List<RouteAssignmentEntity>?> GetAllByTransportIdAsync(Guid trasnportId, CancellationToken cancellationToken) =>
            await _collection.Find(r => r.TransportId == trasnportId).ToListAsync(cancellationToken);

        public async Task AddAsync(RouteAssignmentEntity route, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(route, cancellationToken: cancellationToken);

        public async Task UpdateAsync(RouteAssignmentEntity route, CancellationToken cancellationToken) =>
            await _collection.ReplaceOneAsync(r => r.Id == route.Id, route, cancellationToken: cancellationToken);

        public async Task DeleteAsync(RouteAssignmentEntity route, CancellationToken cancellationToken) =>
            await _collection.DeleteOneAsync(r => r.Id == route.Id, cancellationToken: cancellationToken);
    }
}
