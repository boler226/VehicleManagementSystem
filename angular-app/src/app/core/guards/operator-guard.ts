import {CanActivateFn} from '@angular/router';
import {inject} from '@angular/core';
import {RoleService} from '../services/role.service';

export const operatorGuard: CanActivateFn = (route, state) => {
  const roleService = inject(RoleService);
  return roleService.hasRole('OperatorSD');
};
