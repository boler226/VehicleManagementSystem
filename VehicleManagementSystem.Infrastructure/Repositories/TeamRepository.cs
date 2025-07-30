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

        public async Task<TeamEntity?> GetByPersonIdAsync(Guid personId, CancellationToken cancellationToken) =>
            await _collection.Find(t => 
                    t.ForemanId == personId ||
                    t.MasterId == personId ||
                    t.SectionHeadId == personId ||
                    t.WorkshopHeadId == personId)
            .FirstOrDefaultAsync(cancellationToken);

        public async Task<List<TeamEntity>?> GetAllAsync(CancellationToken cancellationToken) =>
           await _collection.Find(_ => true).ToListAsync(cancellationToken);

        public async Task AddAsync(TeamEntity team, CancellationToken cancellationToken) =>
            await _collection.InsertOneAsync(team, cancellationToken: cancellationToken);

        public async Task UpdateAsync(TeamEntity team, CancellationToken cancellationToken) =>
            await _collection.ReplaceOneAsync(t => t.Id == team.Id, team, cancellationToken: cancellationToken);

        public async Task DeleteAsync(TeamEntity team, CancellationToken cancellationToken) =>
            await _collection.DeleteOneAsync(t =>t.Id == team.Id, cancellationToken: cancellationToken);
    }
}
