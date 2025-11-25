export interface AddPersonCommand {
  fullName: string;
  position: string;
}

export interface UpdatePersonCommand {
  id: string;
  fullName?: string | null;
  position?: string | null;
}
