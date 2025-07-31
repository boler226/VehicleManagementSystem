using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Driver;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Driver.GetAll {
    public class GetAllDriversQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllDriversQuery, List<DriverDto>> {
        public async Task<List<DriverDto>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken) {
            var drivers = await unitOfWork.Drivers.GetAllAsync(cancellationToken)
                ?? throw new Exception("Drivers does not exist");

            foreach (var driver in drivers) 
                driver.Vechicles = await unitOfWork.DriverTransports.GetAllByDriverIdAsync(driver.Id, cancellationToken);
            
            return mapper.Map<List<DriverDto>>(drivers);
        }
    }
}
