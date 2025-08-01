using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Transport.GetAll
{
    public class GetAllTransportsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllTransportsQuery, List<TransportDto>>
    {
        public async Task<List<TransportDto>> Handle(GetAllTransportsQuery request, CancellationToken cancellationToken)
        {
            var transports = await unitOfWork.Transports.GetAllAsync(cancellationToken)
                             ?? throw new Exception("Transports does not exist");

            foreach (var transport in transports) {
                var transportDrivers = await unitOfWork.DriverTransports.GetAllByTransportIdAsync(transport.Id, cancellationToken);

                if (transportDrivers is not null) 
                    transport.Drivers = transportDrivers.ToList();

                var assignments = await unitOfWork.RouteAssignments.GetAllByTransportIdAsync(transport.Id, cancellationToken);

                if (assignments is not null)
                    transport.Assignments = assignments.ToList();
            }

            return mapper.Map<List<TransportDto>>(transports);
        }
    }
}
