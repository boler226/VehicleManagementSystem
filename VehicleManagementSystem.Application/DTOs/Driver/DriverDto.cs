﻿using VehicleManagementSystem.Application.DTOs.Team;

namespace VehicleManagementSystem.Application.DTOs.Driver {
    public class DriverDto {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string LicenseNumber { get; set; } = null!;
        public TeamShortDto Team { get; set; } = null!;
    }

}
