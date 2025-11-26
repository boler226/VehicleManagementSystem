export interface AddMileageRecordCommand {
  date: string;
  kilometers: number;
  transportId: string;
}

export interface UpdateMileageRecordCommand {
  id: string;
  transportId?: string;
  date?: string;
  kilometers?: number;
}
