export interface MileageRecord {
  id: string;
  transport: TransportShort;
  date: string;
  kilometers: number;
}

export interface TransportShort {
  id: string;
  licensePlate: string;
}
