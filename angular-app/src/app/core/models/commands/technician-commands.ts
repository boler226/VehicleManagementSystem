export interface AddTechnicianCommand {
  fullName: string;
  speciality: string;
  teamId: string;
}

export interface UpdateTechnicianCommand {
  id: string;
  fullName?: string | null;
  speciality?: string | null;
  teamId?: string | null;
}
