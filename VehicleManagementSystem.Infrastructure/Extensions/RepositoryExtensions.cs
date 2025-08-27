using Microsoft.Extensions.DependencyInjection;
using VehicleManagementSystem.Domain.Interfaces.Repositories;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Repositories;
using VehicleManagementSystem.Infrastructure.UnitOfWork;

namespace VehicleManagementSystem.Infrastructure.Extensions {
    public static class RepositoryExtensions {
        public static void AddRepositories(this IServiceCollection service) {
            service.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            service.AddScoped<IDriverRepository, DriverRepository>();
            service.AddScoped<ITeamRepository, TeamRepository>();
            service.AddScoped<ITransportRepository, TransportRepository>();
            service.AddScoped<IDriverTransportRepository, DriverTransportRepository>();
            service.AddScoped<IPersonRepository, PersonRepository>();
            service.AddScoped<ITechnicianRepository, TechnicianRepository>();
            service.AddScoped<ITransportRepairRepository, TransportRepairRepository>();
            service.AddScoped<IRepairWorkRepository, RepairWorkRepository>();
            service.AddScoped<IRouteRepository, RouteRepository>();
            service.AddScoped<IRouteAssignmentRepository, RouteAssignmentRepository>();
            service.AddScoped<IMileageRecordRepository, MileageRecordRepository>();
            service.AddScoped<IGarageObjectRepository, GarageObjectRepository>();
        }
    }
}
