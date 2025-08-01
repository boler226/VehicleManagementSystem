﻿using MediatR;
using VehicleManagementSystem.Domain.Entities;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Commands.Technician.Add {
    public class AddTechnicianCommandHandler(
        IUnitOfWork unitOfWork
        ) : IRequestHandler<AddTechnicianCommand, Guid> {
        public async Task<Guid> Handle(AddTechnicianCommand request, CancellationToken cancellationToken) {
            var team = await unitOfWork.Teams.GetByIdAsync(request.TeamId, cancellationToken)
                       ?? throw new Exception("Team not found");

            var technician = new TechnicianEntity {
                Id = Guid.NewGuid(),
                FullName = request.FullName,
                Specialty = request.Specialty,
                Team = team,
                TeamId = team.Id
            };

            await unitOfWork.Technicians.AddAsync(technician, cancellationToken);

            return technician.Id;
        }
    }
}
