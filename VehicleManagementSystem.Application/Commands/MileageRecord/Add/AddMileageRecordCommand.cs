using MediatR;

namespace VehicleManagementSystem.Application.Commands.MileageRecord.Add; 
public record AddMileageRecordCommand(DateTime Date, double Kilometers, Guid TransportId) : IRequest<Guid>;
