using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;

public class DriverRepository : IDriverRepository
{
    private readonly IMongoCollection<DriverEntity> _collection;

    public DriverRepository(MongoDbContext context) {
        _collection = context.GetCollection<DriverEntity>("Drivers");
    }

    public async Task<DriverEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(d => d.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<DriverEntity>?> GetAllByTeamIdAsync(Guid teamId, CancellationToken cancellationToken)
    {
        return await _collection.Find(d => d.TeamId == teamId).ToListAsync(cancellationToken);
    }

    public async Task<List<DriverEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(DriverEntity driver, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(driver, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(DriverEntity driver, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(d => d.Id == driver.Id, driver, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(DriverEntity driver, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(d => d.Id == driver.Id, cancellationToken: cancellationToken);
    }
}