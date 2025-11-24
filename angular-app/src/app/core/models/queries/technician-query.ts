export interface Technician {
  id: string;
  fullName: string;
  specialty: string;
  team: TeamShort;
  repairWorks: RepairWorkShort[];
}

export interface TeamShort {
  id: string;
  name: string;
}

export interface RepairWorkShort {
  id: string;
  partName: string;
  workDescription: string;
}
