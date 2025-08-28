using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.Exceptions;

namespace VehicleManagementSystem.Application.Commands.Technician.Update {
    public class UpdateTechnicianCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateTechnicianCommand, Unit> {
        public async Task<Unit> Handle(UpdateTechnicianCommand request, CancellationToken cancellationToken) {
            var technician = await unitOfWork.Technicians.GetByIdAsync(request.Id, cancellationToken)
                             ?? throw new NotFoundException(nameof(TechnicianEntity), request.Id);

            if (!string.IsNullOrWhiteSpace(request.FullName))
                technician.FullName = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.Speciality))
                technician.Specialty = request.Speciality;

            if (request.TeamId.HasValue) {
                var team = await unitOfWork.Teams.GetByIdAsync(request.TeamId.Value, cancellationToken)
                                 ?? throw new NotFoundException(nameof(TeamEntity), request.TeamId);

                technician.Team = team;
                technician.TeamId = team.Id;
            }

            await unitOfWork.Technicians.UpdateAsync(technician, cancellationToken);

            return Unit.Value;
        }
    }
}
