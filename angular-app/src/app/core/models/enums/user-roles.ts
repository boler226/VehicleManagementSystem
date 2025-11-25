export const UserRoles = {
  AdminSD: 'AdminSD',
  OperatorSD: 'OperatorSD',
  Authorized: 'Authorized',
  Guest: 'Guest'
} as const;

export type UserRole = typeof UserRoles[keyof typeof UserRoles];
