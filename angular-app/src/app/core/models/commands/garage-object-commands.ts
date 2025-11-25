export interface AddGarageObjectCommand {
  name: string;
  location: string;
}

export interface UpdateGarageObjectCommand {
  id: string;
  name: string | null;
  location: string | null;
}
