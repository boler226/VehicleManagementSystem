import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {MileageRecordService} from '../../../core/services/mileage-record.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {MileageRecord} from '../../../core/models/queries/mileage-record-query';
import {FormField} from '../../../core/models/form-config';
import {
  AddMileageRecordCommand,
  UpdateMileageRecordCommand
} from '../../../core/models/commands/mileage-record-commands';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';
import {TransportService} from '../../../core/services/transport.service';
import {Transport} from '../../../core/models/queries/transport-query';

@Component({
  selector: 'app-mileage-records-grid',
  imports: [
    DynamicFormComponent,
    TableComponent,
    AsyncPipe
  ],
  templateUrl: './mileage-records-grid.component.html',
  standalone: true
})
export class MileageRecordsGridComponent {
  private mileageService = inject(MileageRecordService);
  private transportService = inject(TransportService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private recordsSubject = new BehaviorSubject<MileageRecord[]>([]);
  records$: Observable<MileageRecord[]> = this.recordsSubject.asObservable();

  transports: Transport[] = [];

  selectedRecord: MileageRecord | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'transport.licensePlate', header: 'Транспорт' },
    { field: 'date', header: 'Дата' },
    { field: 'kilometers', header: 'Кілометри' }
  ];

  updateFields: FormField[] = [
    { field: 'transportId', label: 'Транспорт', type: 'select', options: [] },
    { field: 'date', label: 'Дата', type: 'date' },
    { field: 'kilometers', label: 'Кілометри', type: 'number' }
  ];

  addFields: FormField[] = [
    { field: 'transportId', label: 'Транспорт', type: 'select', options: [] },
    { field: 'date', label: 'Дата', type: 'date' },
    { field: 'kilometers', label: 'Кілометри', type: 'number' }
  ];

  constructor() {
    this.refresh();

    this.transportService.getAll().subscribe({
      next: transports => {
        this.transports = transports;

        const transportOptions = transports.map(t => ({
          key: t.id, // GUID
          value: `${t.licensePlate} (${t.brand} ${t.model})`
        }));

        this.addFields.find(f => f.field === 'transportId')!.options = transportOptions;
        this.updateFields.find(f => f.field === 'transportId')!.options = transportOptions;
      },
      error: err => console.error('Помилка при завантаженні транспорту', err)
    });
  }

  openAddForm() { this.showAddForm = true; }
  closeAddForm() { this.showAddForm = false; }

  updateRecord(row: MileageRecord) {
    this.selectedRecord = row;
    this.showUpdateForm = true;
  }

  deleteRecord(row: MileageRecord) {
    this.mileageService.delete(row.id).subscribe({
      next: () => { this.refresh(); this.closeForm(); },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedRecord) return;

    const command: UpdateMileageRecordCommand = {
      id: this.selectedRecord.id,
      transportId: updated.transportId || this.selectedRecord.transport?.id,
      date: updated.date || this.selectedRecord.date,
      kilometers: updated.kilometers || this.selectedRecord.kilometers
    };

    this.mileageService.update(command).subscribe({
      next: () => { this.refresh(); this.closeForm(); },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newRecord: any) {
    const command: AddMileageRecordCommand = {
      date: newRecord.date,
      kilometers: Number(newRecord.kilometers),
      transportId: newRecord.transportId
    };

    this.mileageService.add(command).subscribe({
      next: () => { this.refresh(); this.closeAddForm(); },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedRecord = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.mileageService.getAll().subscribe({
      next: records => this.recordsSubject.next(records),
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean { return this.roleService.hasCrudAccess(); }
}
