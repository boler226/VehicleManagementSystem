using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using VehicleManagementSystem.Domain.Entities;

namespace VehicleManagementSystem.Infrastructure.DbContext {
    public class MongoDbContext {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration) {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("VehicleManagement");
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName) =>
            _database.GetCollection<T>(collectionName);

        public IMongoCollection<TransportEntity> Transports => _database.GetCollection<TransportEntity>("Transport");
        public IMongoCollection<DriverEntity> Drivers => _database.GetCollection<DriverEntity>("Drivers");
        public IMongoCollection<DriverTransportEntity> DriverTransports => _database.GetCollection<DriverTransportEntity>("DriverTransports");
        public IMongoCollection<TechnicianEntity> Technicians => _database.GetCollection<TechnicianEntity>("Technicians");
        public IMongoCollection<TeamEntity> Teams => _database.GetCollection<TeamEntity>("Teams");
        public IMongoCollection<PersonEntity> Person => _database.GetCollection<PersonEntity>("Person");
        public IMongoCollection<GarageObjectEntity> GarageObjects => _database.GetCollection<GarageObjectEntity>("GarageObjects");
        public IMongoCollection<RouteEntity> Routes => _database.GetCollection<RouteEntity>("Routes");
        public IMongoCollection<RouteAssignmentEntity> RouteAssignments => _database.GetCollection<RouteAssignmentEntity>("RouteAssignments");
        public IMongoCollection<TransportRepairEntity> TransportRepairs => _database.GetCollection<TransportRepairEntity>("TransportRepairs");
        public IMongoCollection<RepairWorkEntity> RepairWorks => _database.GetCollection<RepairWorkEntity>("RepairWorks");
        public IMongoCollection<MileageRecordEntity> Mileages => _database.GetCollection<MileageRecordEntity>("Mileages");
    }
}
