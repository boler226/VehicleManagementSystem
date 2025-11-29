export interface MileageRecord {
  id: string;
  transport: TransportShort;
  date: string;
  kilometers: number;
}

export interface TransportShort {
  id: string;
  licensePlate: string;
  brand: string;
  model: string;
  type: string;
}

export interface GetMileageRecordByDate {
  date: string;
  category?: string | null;
  transportId?: string | null;
}
