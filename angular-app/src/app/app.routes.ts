import { Routes } from '@angular/router';
import {RegisterComponent} from './features/auth/register/register.component';
import {LoginComponent} from './features/auth/login/login.component';
import {TransportGridComponent} from './features/grids/transport-grid/transport-grid.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'grids/transport', component: TransportGridComponent },
  { path: '', redirectTo: 'grids/transport', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard/overview' }
];
