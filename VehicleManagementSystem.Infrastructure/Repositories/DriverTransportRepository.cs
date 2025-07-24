using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories {
    public class DriverTransportRepository : IDriverTransportRepository {
        private readonly IMongoCollection<DriverTransportEntity> _collection;

        public DriverTransportRepository(MongoDbContext context) {
            _collection = context.GetCollection<DriverTransportEntity>("DriverTransports");
        }

        public async Task<DriverTransportEntity?> GetByDriverIdAsync(Guid driverId, CancellationToken cancellationToken) =>
            await _collection.Find(d => d.DriverId == driverId).FirstOrDefaultAsync(cancellationToken);

        public async Task AddAsync(DriverTransportEntity driverTransport, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(driverTransport, cancellationToken: cancellationToken);

        public async Task DeleteByDriverIdAsync(Guid driverId, CancellationToken cancellationToken) =>
            await _collection.DeleteManyAsync(d => d.DriverId == driverId, cancellationToken);

        public async Task DeleteByTransportIdAsync(Guid transportId, CancellationToken cancellationToken) =>
            await _collection.DeleteManyAsync(d => d.TransportId == transportId, cancellationToken);

    }
}
