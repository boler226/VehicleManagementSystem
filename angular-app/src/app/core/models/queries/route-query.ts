export interface Route {
  id: string;
  routeNumber: string;
  description: string;
  assignments: RouteAssignmentShort[];
}

export interface RouteAssignmentShort {
  id: string;
  date: string;
  passengersCarried: number;
}
