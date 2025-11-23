using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<UserEntity> _collection;

    public UserRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<UserEntity>("Users");
    }

    public async Task<UserEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var filter = Builders<UserEntity>.Filter.Eq(u => u.Email, email);
        return await _collection.Find(filter).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<UserEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(entity, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, entity.Id);
        await _collection.ReplaceOneAsync(filter, entity, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(UserEntity entity, CancellationToken cancellationToken)
    {
        var filter = Builders<UserEntity>.Filter.Eq(u => u.Id, entity.Id);
        await _collection.DeleteOneAsync(filter, cancellationToken);
    }
}