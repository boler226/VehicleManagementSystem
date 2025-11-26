export interface GarageObject {
  id: string;
  name: string | null;
  location: string | null;
  vehiclesStored: TransportShort[];
}

export interface TransportShort {
  id: string;
  licensePlate: string;
}

export interface GarageObjectStatisticsDto {
  id: string;
  name: string;
  totalVehicles: number;
  vehiclesByCategory: { [key: string]: number };
}
