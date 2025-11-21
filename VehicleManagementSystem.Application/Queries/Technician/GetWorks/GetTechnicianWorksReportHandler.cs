using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.RepairWork;
using VehicleManagementSystem.Application.DTOs.Technician;
using VehicleManagementSystem.Application.DTOs.TransportRepair;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Queries.Technician.GetWorks;
public class GetTechnicianWorksReportHandler(
    IRepositoryManager repositoryManager,
    IMapper mapper
    ) : IRequestHandler<GetTechnicianWorksReportQuery, TechnicianWorksReportDto>
{
    public async Task<TechnicianWorksReportDto> Handle(GetTechnicianWorksReportQuery request, CancellationToken cancellationToken)
    {
        var technician = await repositoryManager.Technicians.GetByIdWithWorksAsync(request.TechnicianId, request.FromDate, request.ToDate, cancellationToken)
            ?? throw new NotFoundException(nameof(TechnicianEntity), request.TechnicianId);

        var allWorks = technician.RepairWorks?
            .Where(rw => rw.Repair.RepairDate >= request.FromDate && rw.Repair.RepairDate <= request.ToDate)
            .ToList() ?? new List<RepairWorkEntity>();

        var dto = new TechnicianWorksReportDto
        {
            TechnicianId = technician.Id,
            FullName = technician.FullName,
            Specialty = technician.Specialty,
            TotalWorks = allWorks.Count,
            TotalCost = allWorks.Sum(rw => rw.Repair.Cost),
            Works = mapper.Map<IEnumerable<RepairWorkItemDto>>(allWorks)
        };

        if (request.TransportId.HasValue)
        {
            var vehicleWorks = allWorks.Where(rw => rw.Repair.TransportId == request.TransportId.Value).ToList();
            dto.VehicleWorksCount = vehicleWorks.Count;
            dto.VehicleWorksCost = vehicleWorks.Sum(rw => rw.Repair.Cost);
        }

        return dto;
    }
}
