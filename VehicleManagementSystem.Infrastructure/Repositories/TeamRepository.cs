using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository {
        private readonly IMongoCollection<TeamEntity> _collection;

        public TeamRepository(MongoDbContext context) {
            _collection = context.GetCollection<TeamEntity>("Teams");
        }

        public async Task<TeamEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _collection.Find(t => t.Id == id).FirstOrDefaultAsync(cancellationToken);
    }
}
