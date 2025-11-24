export interface Team {
  id: string;
  name: string;
  foreman?: Person;
  master?: Person;
  sectionHead?: Person;
  workshopHead?: Person;
  drivers: DriverShort[];
  technicians: TechnicianShort[];
}

export interface Person {
  id: string;
  fullName: string;
}

export interface DriverShort {
  id: string;
  fullName: string;
}

export interface TechnicianShort {
  id: string;
  fullName: string;
}
