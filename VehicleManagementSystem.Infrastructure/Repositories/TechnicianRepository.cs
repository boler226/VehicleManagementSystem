using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories {
    public class TechnicianRepository : ITechnicianRepository {
        private readonly IMongoCollection<TechnicianEntity> _collection;

        public TechnicianRepository(MongoDbContext context) {
            _collection = context.GetCollection<TechnicianEntity>("Technicians");
        }

        public async Task<TechnicianEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
         await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<TechnicianEntity>?> GetAllAsync(CancellationToken cancellationToken) =>
            await _collection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task AddAsync(TechnicianEntity technician, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(technician, cancellationToken: cancellationToken);

        public async Task UpdateAsync(TechnicianEntity technician, CancellationToken cancellationToken) =>
            await _collection.ReplaceOneAsync(t => t.Id == technician.Id, technician, cancellationToken: cancellationToken);

        public async Task DeleteAsync(TechnicianEntity technician, CancellationToken cancellationToken) =>
            await _collection.DeleteOneAsync(t => t.Id == technician.Id, cancellationToken: cancellationToken);
    }
}
