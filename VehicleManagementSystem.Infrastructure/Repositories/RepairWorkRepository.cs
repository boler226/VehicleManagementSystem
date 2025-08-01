using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories {
    public class RepairWorkRepository : IRepairWorkRepository {
        private readonly IMongoCollection<RepairWorkEntity> _collection;

        public RepairWorkRepository(MongoDbContext context) {
            _collection = context.GetCollection<RepairWorkEntity>("RepairWorks");
        }

        public async Task<RepairWorkEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
         await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);

        public async Task<List<RepairWorkEntity>?> GetAllAsync(CancellationToken cancellationToken) =>
            await _collection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task<List<RepairWorkEntity>?> GetAllByRepairIdAsync(Guid repairId, CancellationToken cancellationToken) =>
            await _collection.Find(w => w.RepairId == repairId).ToListAsync(cancellationToken);

        public async Task<List<RepairWorkEntity>?> GetAllByTechnicianIdAsync(Guid technicianId, CancellationToken cancellationToken) =>
            await _collection.Find(w => w.TechnicianId == technicianId).ToListAsync(cancellationToken);

        public async Task AddAsync(RepairWorkEntity work, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(work, cancellationToken: cancellationToken);

        public async Task UpdateAsync(RepairWorkEntity work, CancellationToken cancellationToken) =>
            await _collection.ReplaceOneAsync(w => w.Id == work.Id, work, cancellationToken: cancellationToken);

        public async Task DeleteAsync(RepairWorkEntity work, CancellationToken cancellationToken) =>
            await _collection.DeleteOneAsync(w => w.Id == work.Id, cancellationToken: cancellationToken);
    }
}
