import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
@Injectable({
  providedIn: 'root',
})
export class RoleService {
  getRole(): string | null {
    const token = localStorage.getItem('authToken');
    if (!token) return null;

    const decoded: any = jwtDecode(token);
    return decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] ?? null;
  }

  hasRole(role: string): boolean {
    return this.getRole() === role;
  }

  hasCrudAccess(): boolean {
    const role = this.getRole();
    return role === 'AdminSD' || role === 'OperatorSD';
  }
}
