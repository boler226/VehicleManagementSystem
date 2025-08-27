using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories {
    public class GarageObjectRepository : IGarageObjectRepository {
        private readonly IMongoCollection<GarageObjectEntity> _collection;

        public GarageObjectRepository(MongoDbContext context) {
            _collection = context.GetCollection<GarageObjectEntity>("GarageObjects");
        }

        public async Task<GarageObjectEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _collection.Find(g => g.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<GarageObjectEntity>?> GetAllAsync(CancellationToken cancellationToken) =>
            await _collection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task AddAsync(GarageObjectEntity garage, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(garage, cancellationToken: cancellationToken);

        public async Task UpdateAsync(GarageObjectEntity garage, CancellationToken cancellationToken) =>
            await _collection.ReplaceOneAsync(g => g.Id == garage.Id, garage, cancellationToken: cancellationToken);

        public async Task DeleteAsync(GarageObjectEntity garage, CancellationToken cancellationToken) =>
            await _collection.DeleteOneAsync(g => g.Id == garage.Id, cancellationToken: cancellationToken);
    }
}
