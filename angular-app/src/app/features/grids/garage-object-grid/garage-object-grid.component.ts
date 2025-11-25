import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {AddGarageObjectCommand, UpdateGarageObjectCommand} from '../../../core/models/commands/garage-object-commands';
import {GarageObject} from '../../../core/models/queries/garage-object-query';
import {GarageObjectService} from '../../../core/services/garage-object.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {FormField} from '../../../core/models/form-config';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {AsyncPipe} from '@angular/common';
import {TableComponent} from '../../../shared/table/table.component';

@Component({
  selector: 'app-garage-object-grid',
  imports: [
    DynamicFormComponent,
    AsyncPipe,
    TableComponent
  ],
  templateUrl: './garage-object-grid.component.html',
  standalone: true
})
export class GarageObjectGridComponent {
  private garageService = inject(GarageObjectService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private garageObjectsSubject = new BehaviorSubject<GarageObject[]>([]);
  garageObjects$: Observable<GarageObject[]> = this.garageObjectsSubject.asObservable();

  selectedGarage: GarageObject | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'name', header: 'Назва' },
    { field: 'location', header: 'Локація' },
    { field: 'vehiclesNames', header: 'Транспорт' }
  ];

  updateFields: FormField[] = [
    { field: 'name', label: 'Назва', type: 'text' },
    { field: 'location', label: 'Локація', type: 'text' }
  ];

  addFields: FormField[] = [
    { field: 'name', label: 'Назва', type: 'text' },
    { field: 'location', label: 'Локація', type: 'text' }
  ];

  constructor() {
    this.refresh();
  }

  openAddForm() {
    this.showAddForm = true;
  }

  closeAddForm() {
    this.showAddForm = false;
  }

  updateGarage(row: GarageObject) {
    this.selectedGarage = row;
    this.showUpdateForm = true;
  }

  deleteGarage(row: GarageObject) {
    this.garageService.delete(row.id).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedGarage) return;

    const command: UpdateGarageObjectCommand = {
      id: this.selectedGarage.id,
      name: updated.name === '' ? null : updated.name,
      location: updated.location === '' ? null : updated.location
    };

    this.garageService.update(command).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newGarage: any) {
    const command: AddGarageObjectCommand = {
      name: newGarage.name,
      location: newGarage.location
    };

    this.garageService.add(command).subscribe({
      next: () => {
        this.refresh();
        this.closeAddForm();
      },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedGarage = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.garageService.getAll().subscribe({
      next: garages => {
        const mapped = garages.map(g => ({
          ...g,
          vehiclesNames: g.vehiclesStored.length > 0
            ? g.vehiclesStored.map(v => v.licensePlate).join(', ')
            : null
        }));
        this.garageObjectsSubject.next(mapped as any);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
