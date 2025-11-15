using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Infrastructure.DbContext;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class PersonRepository : IPersonRepository {
    private readonly IMongoCollection<PersonEntity> _collection;

    public PersonRepository(MongoDbContext context) {
        _collection = context.GetCollection<PersonEntity>("Persons");
    }

    public async Task<PersonEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<PersonEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(PersonEntity person, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(person, cancellationToken: cancellationToken);
    }

    public async Task UpdateAsync(PersonEntity person, CancellationToken cancellationToken)
    {
        await _collection.ReplaceOneAsync(p => p.Id == person.Id, person, cancellationToken: cancellationToken);
    }

    public async Task DeleteAsync(PersonEntity person, CancellationToken cancellationToken)
    {
        await _collection.DeleteOneAsync(p => p.Id == person.Id, cancellationToken: cancellationToken);
    }
}