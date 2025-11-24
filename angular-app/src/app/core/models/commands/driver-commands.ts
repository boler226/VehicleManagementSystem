export interface AddDriverCommand {
  fullName: string;
  teamId: string;
}

export interface UpdateDriverCommand {
  id: string;
  fullName?: string | null;
  teamId?: string | null;
}
