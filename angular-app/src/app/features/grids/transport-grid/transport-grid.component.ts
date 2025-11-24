import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {Transport} from '../../../core/models/queries/transport-query';
import {TransportEnum} from '../../../core/models/enums/transport-enum';
import {BehaviorSubject, Observable} from 'rxjs';
import {TransportService} from '../../../core/services/transport.service';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';
import {FormField} from '../../../core/models/form-config';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {
  AddTransportCommand,
  UpdateTransportCommand
} from '../../../core/models/commands/transport-commands';
import {RoleService} from '../../../core/services/role.service';

@Component({
  selector: 'app-transport-grid',
  imports: [
    TableComponent,
    AsyncPipe,
    DynamicFormComponent
  ],
  templateUrl: './transport-grid.component.html',
  standalone: true
})
export class TransportGridComponent {
  private transportService = inject(TransportService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);
  private transportsSubject = new BehaviorSubject<Transport[]>([]);
  transports$: Observable<Transport[]> = this.transportsSubject.asObservable();

  selectedTransport: Transport | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'licensePlate', header: 'Номерний знак' },
    { field: 'brand', header: 'Марка' },
    { field: 'model', header: 'Модель' },
    { field: 'type', header: 'Тип' },
    { field: 'capacity', header: 'Місткість' },
    { field: 'loadCapacity', header: 'Вантажопідйомність' }
  ];

  updateFields: FormField[] = [
    { field: 'licensePlate', label: 'Номерний знак', type: 'text' },
    { field: 'brand', label: 'Марка', type: 'text' },
    { field: 'model', label: 'Модель', type: 'text' },
    {
      field: 'type',
      label: 'Тип',
      type: 'select',
      options: Object.keys(TransportEnum).filter(k => isNaN(Number(k)))
    },
    { field: 'capacity', label: 'Місткість', type: 'number' },
    { field: 'loadCapacity', label: 'Вантажопідйомність', type: 'number' }
  ];

  addFields: FormField[] = [
    { field: 'licensePlate', label: 'Номерний знак', type: 'text' },
    { field: 'brand', label: 'Марка', type: 'text' },
    { field: 'model', label: 'Модель', type: 'text' },
    {
      field: 'type',
      label: 'Тип',
      type: 'select',
      options: Object.keys(TransportEnum).filter(k => isNaN(Number(k)))
    },
    { field: 'capacity', label: 'Місткість', type: 'number' },
    { field: 'loadCapacity', label: 'Вантажопідйомність', type: 'number' }
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

  updateTransport(row: Transport) {
    this.selectedTransport = row;
    this.showUpdateForm = true;
  }

  deleteTransport(row: Transport) {
    this.transportService.delete(row.id).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedTransport) return;

    const command: UpdateTransportCommand = {
      id: this.selectedTransport.id,
      garageId: this.selectedTransport.garageObject?.id ?? null,
      licensePlate: updated.licensePlate === "" ? null : updated.licensePlate,
      type: updated.type === "" ? null : updated.type,
      capacity: updated.capacity === "" ? null : Number(updated.capacity),
      loadCapacity: updated.loadCapacity === "" ? null : Number(updated.loadCapacity)
    };

    this.transportService.update(command).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newTransport: any) {
    const command: AddTransportCommand = {
      garageId: newTransport.garageId || undefined,
      licensePlate: newTransport.licensePlate,
      brand: newTransport.brand,
      model: newTransport.model,
      type: newTransport.type,
      capacity: newTransport.capacity === "" ? undefined : Number(newTransport.capacity),
      loadCapacity: newTransport.loadCapacity === "" ? undefined : Number(newTransport.loadCapacity)
    };

    this.transportService.add(command).subscribe({
      next: () => {
        this.refresh();
        this.closeAddForm();
      },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedTransport = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.transportService.getAll().subscribe({
      next: transports => this.transportsSubject.next(transports),
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
