using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Manager;
using VehicleManagementSystem.Infrastructure.Repositories;

namespace VehicleManagementSystem.Infrastructure.Extensions; 
public static class RepositoryExtensions {
    public static void AddRepositories(this IServiceCollection service) {
        service.Scan(scan => scan
            .FromAssemblyOf<DriverRepository>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime()
        );

        service.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
