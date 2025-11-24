export interface Transport {
  id: string;
  licensePlate: string;
  brand: string;
  model: string;
  type: string;
  capacity?: number;
  loadCapacity?: number;

  acquisitionDate?: string;
  isWrittenOff: boolean;
  writeOffDate?: string;

  garageObject?: GarageObjectShort;
  drivers?: DriverShort[];
  assignments?: RouteAssignmentShort[];
  mileages?: MileageRecordShort[];
}

export interface GarageObjectShort {
  id: string;
  name: string;
}

export interface DriverShort {
  id: string;
  fullName: string;
}

export interface RouteAssignmentShort {
  id: string;
  routeName: string;
}

export interface MileageRecordShort {
  id: string;
  mileage: number;
}
