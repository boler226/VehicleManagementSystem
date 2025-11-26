export interface AddRouteCommand {
  routeNumber: string;
  description: string;
}

export interface UpdateRouteCommand {
  id: string;
  routeNumber?: string | null;
  description?: string | null;
}
