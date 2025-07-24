using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces.Repositories;

namespace VehicleManagementSystem.Application.Queries.Transport.GetAll
{
    public class GetAllTransportsQueryHandler(
        ITransportRepository repository,
        IMapper mapper
        ) : IRequestHandler<GetAllTransportsQuery, List<TransportDto>>
    {
        public async Task<List<TransportDto>> Handle(GetAllTransportsQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetAllAsync(cancellationToken)
                ?? throw new Exception("Transports does not exist");

            return mapper.Map<List<TransportDto>>(result);
        }
    }
}
