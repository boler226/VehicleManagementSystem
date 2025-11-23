using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities.Identity;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Infrastructure.Repositories;
public class RegistrationRequestRepository : IRegistrationRequestRepository
{
    private readonly IMongoCollection<RegistrationRequest> _collection;

    public RegistrationRequestRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<RegistrationRequest>("RegistrationRequests");
    }

    public async Task AddAsync(RegistrationRequest request, CancellationToken cancellationToken)
    {
        await _collection.InsertOneAsync(request, cancellationToken: cancellationToken);
    }

    public async Task<RegistrationRequest?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _collection.Find(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<RegistrationRequest>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _collection.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task UpdateAsync(RegistrationRequest request, CancellationToken cancellationToken)
    {
        var filter = Builders<RegistrationRequest>.Filter.Eq(r => r.Id, request.Id);
        await _collection.ReplaceOneAsync(filter, request, cancellationToken: cancellationToken);
    }
}