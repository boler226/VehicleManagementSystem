using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories
{
    public class TransportRepository : ITransportRepository {
        private readonly IMongoCollection<TransportEntity> _collection;

        public TransportRepository(MongoDbContext context) {
            _collection = context.GetCollection<TransportEntity>("Transports");
        }

        public async Task<TransportEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _collection.Find(t => t.Id == id).FirstOrDefaultAsync(cancellationToken);


        public async Task<List<TransportEntity>?> GetAllsync(CancellationToken cancellationToken) =>
            await _collection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task<TransportEntity?> GetWithRoutesByPeriodAsync(Guid id, DateTime from, DateTime to, CancellationToken cancellationToken) {
            var filter = Builders<TransportEntity>.Filter.Eq(t => t.Id, id);
            var projection = Builders<TransportEntity>.Projection.Expression(t => new TransportEntity {
                Id = t.Id,
                LicensePlate = t.LicensePlate,
                Brand = t.Brand,
                Model = t.Model,
                Type = t.Type,
                Capacity = t.Capacity,
                LoadCapacity = t.LoadCapacity,
                IsWrittenOff = t.IsWrittenOff,
                WriteOffDate = t.WriteOffDate,
                RouteAssignments = t.RouteAssignments
                    .Where(r => r.Date >= from && r.Date <= to)
                    .ToList()
            });

            var pipeline = _collection.Find(filter).Project(projection);

            return await pipeline.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task AddAsync(TransportEntity transport, CancellationToken cancellationToken) {
            await _collection.InsertOneAsync(transport, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(TransportEntity transport, CancellationToken cancellationToken) {
            var filter = Builders<TransportEntity>.Filter.Eq(t => t.Id, transport.Id);
            await _collection.ReplaceOneAsync(filter, transport, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(TransportEntity transport, CancellationToken cancellationToken) {
            var filter = Builders<TransportEntity>.Filter.Eq(t => t.Id, transport.Id);
            await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
        }
    }
}
