using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Driver.GetAll; 
public class GetAllDriversQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllDriversQuery, List<DriverDto>> {
    public async Task<List<DriverDto>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken) {
        var drivers = await manager.Drivers.GetAllAsync(cancellationToken);

        if (drivers is not null) {
            foreach (var driver in drivers)
                driver.Vechicles = await manager.DriverTransports.GetAllByDriverIdAsync(driver.Id, cancellationToken);
        }
        
        return mapper.Map<List<DriverDto>>(drivers);
    }
}
