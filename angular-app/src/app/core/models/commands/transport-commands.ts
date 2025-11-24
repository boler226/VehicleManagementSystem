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
