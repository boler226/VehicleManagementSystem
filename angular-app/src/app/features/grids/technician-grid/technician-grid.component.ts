import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {TechnicianService} from '../../../core/services/technician.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {Technician} from '../../../core/models/queries/technician-query';
import {FormField} from '../../../core/models/form-config';
import {AddTechnicianCommand, UpdateTechnicianCommand} from '../../../core/models/commands/technician-commands';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-technician-grid',
  imports: [
    DynamicFormComponent,
    TableComponent,
    AsyncPipe
  ],
  templateUrl: './technician-grid.component.html',
  standalone: true
})
export class TechnicianGridComponent {
  private technicianService = inject(TechnicianService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private techniciansSubject = new BehaviorSubject<Technician[]>([]);
  technicians$: Observable<Technician[]> = this.techniciansSubject.asObservable();

  selectedTechnician: Technician | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'fullName', header: 'ПІБ' },
    { field: 'specialty', header: 'Спеціальність' },
    { field: 'teamName', header: 'Команда' },
    { field: 'repairWorksNames', header: 'Роботи' }
  ];

  updateFields: FormField[] = [
    { field: 'fullName', label: 'ПІБ', type: 'text' },
    { field: 'specialty', label: 'Спеціальність', type: 'text' },
    { field: 'teamId', label: 'Команда', type: 'text' }
  ];

  addFields: FormField[] = [
    { field: 'fullName', label: 'ПІБ', type: 'text' },
    { field: 'specialty', label: 'Спеціальність', type: 'text' },
    { field: 'teamId', label: 'Команда', type: 'text' }
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

  updateTechnician(row: Technician) {
    this.selectedTechnician = {
      ...row,
      teamId: row.team?.id
    } as any;
    this.showUpdateForm = true;
  }

  deleteTechnician(row: Technician) {
    this.technicianService.delete(row.id).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedTechnician) return;

    const command: UpdateTechnicianCommand = {
      id: this.selectedTechnician.id,
      fullName: updated.fullName === "" ? null : updated.fullName,
      speciality: updated.speciailty === "" ? null : updated.specialty,
      teamId: updated.teamId === "" ? null : updated.teamId
    };

    this.technicianService.update(command).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newTech: any) {
    const command: AddTechnicianCommand = {
      fullName: newTech.fullName,
      speciality: newTech.specialty,
      teamId: newTech.teamId
    };

    this.technicianService.add(command).subscribe({
      next: () => {
        this.refresh();
        this.closeAddForm();
      },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedTechnician = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.technicianService.getAll().subscribe({
      next: techs => {
        const mapped = techs.map(t => ({
          ...t,
          teamName: t.team?.name ?? '',
          repairWorksNames: t.repairWorks.map(r => r.partName).join(', ')
        }));
        this.techniciansSubject.next(mapped as any);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
