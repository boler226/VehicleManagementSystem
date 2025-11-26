import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {DriverService} from '../../../core/services/driver.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {Driver} from '../../../core/models/queries/driver-query';
import {FormField} from '../../../core/models/form-config';
import {AddDriverCommand, UpdateDriverCommand} from '../../../core/models/commands/driver-commands';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {AsyncPipe} from '@angular/common';
import {TableComponent} from '../../../shared/table/table.component';
import {TeamService} from '../../../core/services/team.service';

@Component({
  selector: 'app-driver-grid',
  imports: [
    DynamicFormComponent,
    AsyncPipe,
    TableComponent
  ],
  standalone: true,
  templateUrl: './driver-grid.component.html'
})
export class DriverGridComponent {
  private driverService = inject(DriverService);
  private teamService = inject(TeamService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private driversSubject = new BehaviorSubject<Driver[]>([]);
  drivers$: Observable<Driver[]> = this.driversSubject.asObservable();

  selectedDriver: Driver | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'fullName', header: 'ПІБ' },
    { field: 'teamName', header: 'Команда' }
  ];

  updateFields: FormField[] = [
    { field: 'fullName', label: 'ПІБ', type: 'text' },
    { field: 'teamId', label: 'Команда', type: 'select', options: [] }
  ];

  addFields: FormField[] = [
    { field: 'fullName', label: 'ПІБ', type: 'text' },
    { field: 'teamId', label: 'Команда', type: 'select', options: [] }
  ];

  constructor() {
    this.refresh();

    this.teamService.getAll().subscribe({
      next: teams => {
        const teamOptions = teams.map(t => ({
          key: t.id,
          value: t.name
        }));

        this.addFields.find(f => f.field === 'teamId')!.options = teamOptions;
        this.updateFields.find(f => f.field === 'teamId')!.options = teamOptions;
      },
      error: err => console.error('Помилка при завантаженні команд', err)
    });  }

  openAddForm() {
    this.showAddForm = true;
  }

  closeAddForm() {
    this.showAddForm = false;
  }

  updateDriver(row: Driver) {
    this.selectedDriver = row;
    this.showUpdateForm = true;
  }

  deleteDriver(row: Driver) {
    this.driverService.delete(row.id).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedDriver) return;

    const command: UpdateDriverCommand = {
      id: this.selectedDriver.id,
      fullName: updated.fullName === "" ? null : updated.fullName,
      teamId: updated.teamId === "" ? null : updated.teamId
    };

    this.driverService.update(command).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newDriver: any) {
    const command: AddDriverCommand = {
      fullName: newDriver.fullName,
      teamId: newDriver.teamId
    };

    this.driverService.add(command).subscribe({
      next: () => {
        this.refresh();
        this.closeAddForm();
      },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedDriver = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.driverService.getAll().subscribe({
      next: drivers => {
        const mapped = drivers.map(d => ({
          ...d,
          teamName: d.team?.name
        }));
        this.driversSubject.next(mapped as any);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
