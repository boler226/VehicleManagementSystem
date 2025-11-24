export interface AddTeamCommand {
  name: string;
  foremanId?: string;
  masterId?: string;
  sectionHeadId?: string;
  workshopHeadId?: string;
}

export interface UpdateTeamCommand {
  id: string;
  name: string;
  foremanId?: string;
  masterId?: string;
  sectionHeadId?: string;
  workshopHeadId?: string;
}
