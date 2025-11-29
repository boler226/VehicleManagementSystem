export interface AddTransportRepairCommand {
  transportId: string;
  garageId?: string | null;
  cost: number;
}

export interface UpdateTransportRepairCommand {
  id: string;
  garageId?: string | null;
  repairDate?: string | null;
  cost?: number | null;
}
