import { Routes } from '@angular/router';
import {RegisterComponent} from './features/auth/register/register.component';
import {LoginComponent} from './features/auth/login/login.component';
import {DataOverviewComponent} from './features/dashboard/data-overview/data-overview.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'dashboard/overview', component: DataOverviewComponent },
  { path: '', redirectTo: 'dashboard/overview', pathMatch: 'full' },
  { path: '**', redirectTo: 'dashboard/overview' }
];
