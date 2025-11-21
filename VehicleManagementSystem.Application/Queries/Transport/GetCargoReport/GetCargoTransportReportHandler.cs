using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Transport;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Enums;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Queries.Transport.GetCargoReport;
public class GetCargoTransportReportHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetCargoTransportReportQuery, CargoTransportReportDto>
{
    public async Task<CargoTransportReportDto> Handle(GetCargoTransportReportQuery request, CancellationToken cancellationToken)
    {
        var transport = await repositoryManager.Transports.GetByIdAsync(request.Id, cancellationToken)
           ?? throw new NotFoundException(nameof(TransportEntity), request.Id);

        if (transport.Type != TransportEnum.Truck)
            throw new InvalidOperationException($"Transport {transport.LicensePlate} is not a cargo vehicle.");

        var assignments = transport.Assignments
            .Where(a => a.Date >= request.FromDate && a.Date <= request.ToDate)
            .ToList();

        var dto = mapper.Map<CargoTransportReportDto>(transport);
        dto.TripsCount = assignments.Count;
        dto.TotalCargoWeight = assignments.Sum(a => a.Transport.LoadCapacity ?? 0);
        dto.FromDate = request.FromDate;
        dto.ToDate = request.ToDate;

        return dto;
    }
}
