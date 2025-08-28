﻿using AutoMapper;
using MediatR;
using VehicleManagementSystem.Application.DTOs.Person;
using VehicleManagementSystem.Domain.Interfaces;

namespace VehicleManagementSystem.Application.Queries.Person.GetAll {
    public class GetAllPersonsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper
        ) : IRequestHandler<GetAllPersonsQuery, List<PersonDto>> {
        public async Task<List<PersonDto>> Handle(GetAllPersonsQuery request, CancellationToken cancellationToken) {
            var persons = await unitOfWork.Persons.GetAllAsync(cancellationToken);

            return mapper.Map<List<PersonDto>>(persons);
        }
    }
}
