export interface UpdateTransportCommand {
  id: string;
  garageId?: string | null;
  licensePlate?: string | null;
  type?: string | null;
  capacity?: number | null;
  loadCapacity?: number | null;
}

export interface AddTransportCommand {
  garageId?: string | null;
  licensePlate: string;
  brand: string;
  model: string;
  type: string;
  capacity?: number | null;
  loadCapacity?: number | null;
}

export enum TransportEnum {
  Bus = 0,
  Taxi = 1,
  Minibus = 2,
  PassengerCar = 3,
  Truck = 4,
  Auxiliary = 5
}
