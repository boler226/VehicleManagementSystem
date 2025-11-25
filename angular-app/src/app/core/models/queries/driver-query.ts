export interface Driver {
  id: string;
  fullName: string;
  team: TeamShort;
  vehicles?: TransportShort[];
}

export interface TeamShort {
  id: string;
  name: string;
}

export interface TransportShort {
  id: string;
  licensePlate: string;
}
