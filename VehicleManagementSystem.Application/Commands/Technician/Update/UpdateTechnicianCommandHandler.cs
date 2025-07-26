using MediatR;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Technician.Update {
    public class UpdateTechnicianCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<UpdateTechnicianCommand, Unit> {
        public async Task<Unit> Handle(UpdateTechnicianCommand request, CancellationToken cancellationToken) {
            var technician = await unitOfWork.Technicians.GetByIdAsync(request.Id, cancellationToken)
                             ?? throw new Exception("Technician not found");

            if (!string.IsNullOrWhiteSpace(request.FullName))
                technician.FullName = request.FullName;

            if (!string.IsNullOrWhiteSpace(request.Speciality))
                technician.Specialty = request.Speciality;

            if (request.TeamId.HasValue) {
                var team = await unitOfWork.Teams.GetByIdAsync(request.TeamId.Value, cancellationToken)
                    ?? throw new Exception("Team not found");

                technician.Team = team;
                technician.TeamId = team.Id;
            }

            await unitOfWork.Technicians.UpdateAsync(technician, cancellationToken);

            return Unit.Value;
        }
    }
}
