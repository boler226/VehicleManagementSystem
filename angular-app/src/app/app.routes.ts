import { Routes } from '@angular/router';
import {RegisterComponent} from './features/auth/register/register.component';
import {LoginComponent} from './features/auth/login/login.component';
import {TransportGridComponent} from './features/grids/transport-grid/transport-grid.component';
import {DriverGridComponent} from './features/grids/driver-grid/driver-grid.component';
import {TeamGridComponent} from './features/grids/team-grid/team-grid.component';
import {TechnicianGridComponent} from './features/grids/technician-grid/technician-grid.component';
import {GarageObjectGridComponent} from './features/grids/garage-object-grid/garage-object-grid.component';
import {adminGuard} from './core/guards/admin-guard';
import {
  RegistrationRequestGridComponent
} from './features/grids/registration-request-grid/registration-request-grid.component';
import {PersonGridComponent} from './features/grids/person-grid/person-grid.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'grids/transport', component: TransportGridComponent },
  { path: 'grids/driver', component: DriverGridComponent },
  { path: 'grids/team', component: TeamGridComponent },
  { path: 'grids/person', component: PersonGridComponent },
  { path: 'grids/technician', component: TechnicianGridComponent },
  { path: 'grids/garage-object', component: GarageObjectGridComponent },
  {
    path: 'grids/registration-requests',
    component: RegistrationRequestGridComponent,
    canActivate: [adminGuard]
  },
  { path: '', redirectTo: 'grids/transport', pathMatch: 'full' },
  { path: '**', redirectTo: 'grids/transport' }
];
