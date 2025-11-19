using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.GarageObject;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.GarageObject.GetAll; 
public class GetAllGarageObjectQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllGarageObjectQuery, List<GarageObjectDto>> {
    public async Task<List<GarageObjectDto>> Handle(GetAllGarageObjectQuery request, CancellationToken cancellationToken) {
        var garageObjects = await manager.GarageObjects.GetAllAsync(cancellationToken);

        if (garageObjects is not null) {
            foreach (var garage in garageObjects) 
                garage.VehiclesStored = await manager.Transports.GetByGarageIdAsync(garage.Id, cancellationToken);
        }

        return mapper.Map<List<GarageObjectDto>>(garageObjects);
    }
}
