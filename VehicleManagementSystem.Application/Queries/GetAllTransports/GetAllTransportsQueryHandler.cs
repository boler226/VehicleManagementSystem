using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.GetAllTransports
{
    public class GetAllTransportsQueryHandler(
        ITransportRepository repository,
        IMapper mapper
        ) : IRequestHandler<GetAllTransportsQuery, List<TransportDto>> {
        public async Task<List<TransportDto>> Handle(GetAllTransportsQuery request, CancellationToken cancellationToken) {
            var result = await repository.GetAllsync(cancellationToken);

            if (result is null) {
                throw new Exception("Transport does not exist");
            }

            return mapper.Map<List<TransportDto>>(result);
        }
    }
}
