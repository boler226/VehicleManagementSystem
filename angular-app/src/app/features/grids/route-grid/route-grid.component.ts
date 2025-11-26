import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {RouteService} from '../../../core/services/route.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {Route} from '../../../core/models/queries/route-query';
import {FormField} from '../../../core/models/form-config';
import {AddRouteCommand, UpdateRouteCommand} from '../../../core/models/commands/route-commands';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-route-grid',
  imports: [
    DynamicFormComponent,
    TableComponent,
    AsyncPipe
  ],
  templateUrl: './route-grid.component.html',
  standalone: true
})
export class RouteGridComponent {
  private routeService = inject(RouteService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private routesSubject = new BehaviorSubject<Route[]>([]);
  routes$: Observable<Route[]> = this.routesSubject.asObservable();

  selectedRoute: Route | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'routeNumber', header: 'Номер маршруту' },
    { field: 'description', header: 'Опис' }
  ];

  updateFields: FormField[] = [
    { field: 'routeNumber', label: 'Номер маршруту', type: 'text' },
    { field: 'description', label: 'Опис', type: 'text' }
  ];

  addFields: FormField[] = [
    { field: 'routeNumber', label: 'Номер маршруту', type: 'text' },
    { field: 'description', label: 'Опис', type: 'text' }
  ];

  constructor() {
    this.refresh();
  }

  openAddForm() { this.showAddForm = true; }
  closeAddForm() { this.showAddForm = false; }

  updateRoute(row: Route) {
    this.selectedRoute = row;
    this.showUpdateForm = true;
  }

  deleteRoute(row: Route) {
    this.routeService.delete(row.id).subscribe({
      next: () => { this.refresh(); this.closeForm(); },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedRoute) return;

    const command: UpdateRouteCommand = {
      id: this.selectedRoute.id,
      routeNumber: updated.routeNumber === "" ? null : updated.routeNumber,
      description: updated.description === "" ? null : updated.description
    };

    this.routeService.update(command).subscribe({
      next: () => { this.refresh(); this.closeForm(); },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newRoute: any) {
    const command: AddRouteCommand = {
      routeNumber: newRoute.routeNumber,
      description: newRoute.description
    };

    this.routeService.add(command).subscribe({
      next: () => { this.refresh(); this.closeAddForm(); },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedRoute = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.routeService.getAll().subscribe({
      next: routes => this.routesSubject.next(routes),
      error: err => console.error('Помилка при завантаженні маршрутів', err)
    });
  }

  get canCrud(): boolean { return this.roleService.hasCrudAccess(); }
}
