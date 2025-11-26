import { Routes } from '@angular/router';
import {RegisterComponent} from './features/auth/register/register.component';
import {LoginComponent} from './features/auth/login/login.component';
import {TransportGridComponent} from './features/grids/transport-grid/transport-grid.component';
import {DriverGridComponent} from './features/grids/driver-grid/driver-grid.component';
import {TeamGridComponent} from './features/grids/team-grid/team-grid.component';
import {TechnicianGridComponent} from './features/grids/technician-grid/technician-grid.component';
import {GarageObjectGridComponent} from './features/grids/garage-object-grid/garage-object-grid.component';
import {adminGuard} from './core/guards/admin-guard';
import {RegistrationRequestGridComponent} from './features/grids/registration-request-grid/registration-request-grid.component';
import {PersonGridComponent} from './features/grids/person-grid/person-grid.component';
import {DriverTransportsGridComponent} from './features/grids/driver-transports-grid/driver-transports-grid.component';
import {operatorGuard} from './core/guards/operator-guard';
import {ExtraComponent} from './features/extra/extra.component';
import {CargoReportGridComponent} from './features/extra/grids/cargo-report-grid/cargo-report-grid.component';
import {
  GarageStatisticsGridComponent
} from './features/extra/grids/garage-statistics-grid/garage-statistics-grid.component';
import {MileageRecordsGridComponent} from './features/grids/mileage-records-grid/mileage-records-grid.component';
import {RouteGridComponent} from './features/grids/route-grid/route-grid.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'extra', component: ExtraComponent },
  {
    path: 'extra/1',
    component: CargoReportGridComponent
  },
  {
    path: 'extra/2',
    component: GarageStatisticsGridComponent
  },
  { path: 'grids/transport', component: TransportGridComponent },
  { path: 'grids/mileage-record', component: MileageRecordsGridComponent },
  { path: 'grids/route', component: RouteGridComponent },
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
  {
    path: 'grids/driver-transport',
    component: DriverTransportsGridComponent,
    canActivate: [adminGuard || operatorGuard]
  },
  { path: '', redirectTo: 'grids/transport', pathMatch: 'full' },
  { path: '**', redirectTo: 'grids/transport' }
];
