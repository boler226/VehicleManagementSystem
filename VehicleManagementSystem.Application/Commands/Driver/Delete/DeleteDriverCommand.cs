using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Application.Commands.Driver.Delete {
    public record DeleteDriverCommand(Guid Id) : IRequest<Unit>;
}
