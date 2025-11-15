using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Transport.GetAll;

public class GetAllTransportsQueryHandler(
    IRepositoryManager manager,
    IMapper mapper
    ) : IRequestHandler<GetAllTransportsQuery, List<TransportDto>>
{
    public async Task<List<TransportDto>> Handle(GetAllTransportsQuery request, CancellationToken cancellationToken)
    {
        var transports = await manager.Transports.GetAllAsync(cancellationToken);

        if (transports is not null) {
            foreach (var transport in transports) {
                var transportDrivers = await manager.DriverTransports.GetAllByTransportIdAsync(transport.Id, cancellationToken);

                if (transportDrivers is not null)
                    transport.Drivers = transportDrivers.ToList();

                var assignments = await manager.RouteAssignments.GetAllByTransportIdAsync(transport.Id, cancellationToken);

                if (assignments is not null)
                    transport.Assignments = assignments.ToList();

                var milegeas = await manager.MileageRecords.GetAllByTransportIdAsync(transport.Id, cancellationToken);

                if (milegeas is not null)
                    transport.Mileages = milegeas.ToList();
            }
        }

        return mapper.Map<List<TransportDto>>(transports);
    }
}
