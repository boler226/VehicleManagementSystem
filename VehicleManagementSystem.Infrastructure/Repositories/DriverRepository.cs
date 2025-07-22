using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories {
    public class DriverRepository : IDriverRepository {
        private readonly IMongoCollection<DriverEntity> _collection;

        public DriverRepository(MongoDbContext context) {
            _collection = context.GetCollection<DriverEntity>("Drivers");
        }

        public async Task<DriverEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _collection.Find(d => d.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task AddAsync(DriverEntity driver, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(driver, cancellationToken: cancellationToken);

        public async Task UpdateAsync(DriverEntity driver, CancellationToken cancellationToken) {
            var filter = Builders<DriverEntity>.Filter.Eq(d => d.Id, driver.Id);
            await _collection.ReplaceOneAsync(filter, driver, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(DriverEntity driver, CancellationToken cancellationToken) {
            var filter = Builders<DriverEntity>.Filter.Eq(d => d.Id, driver.Id);
            await _collection.DeleteOneAsync(filter, cancellationToken: cancellationToken);
        }
    }
}
