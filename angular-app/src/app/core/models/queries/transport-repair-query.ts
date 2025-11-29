export interface TransportRepairDto {
  id: string;
  transport: TransportShortDto;
  repairDate: string;
  cost: number;
  garageObject?: GarageObjectShortDto | null;
  repairWorks: RepairWorkShortDto[];
}

export interface TransportShortDto {
  id: string;
  licensePlate: string;
  brand: string;
  model: string;
  type: string;
}

export interface GarageObjectShortDto {
  id: string;
  name: string;
  location: string;
}

export interface RepairWorkShortDto {
  id: string;
  partName: string;
  workDescription: string;
}
