import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {FormField} from '../../../core/models/form-config';
import {TeamService} from '../../../core/services/team.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {Team} from '../../../core/models/queries/team-query';
import {AddTeamCommand, UpdateTeamCommand} from '../../../core/models/commands/team-commands';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';

@Component({
  selector: 'app-team-grid',
  imports: [
    TableComponent,
    AsyncPipe,
    DynamicFormComponent
  ],
  templateUrl: './team-grid.component.html',
  standalone: true
})
export class TeamGridComponent {
  private teamService = inject(TeamService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private teamsSubject = new BehaviorSubject<Team[]>([]);
  teams$: Observable<Team[]> = this.teamsSubject.asObservable();

  selectedTeam: Team | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'name', header: 'Назва команди' },
    { field: 'foremanName', header: 'Бригадир' },
    { field: 'masterName', header: 'Майстер' },
    { field: 'sectionHeadName', header: 'Начальник секції' },
    { field: 'workshopHeadName', header: 'Начальник цеху' },
    { field: 'driversNames', header: 'Водії' },
    { field: 'techniciansNames', header: 'Техніки' }
  ];

  updateFields: FormField[] = [
    { field: 'name', label: 'Назва команди', type: 'text' }
  ];

  addFields: FormField[] = [
    { field: 'name', label: 'Назва команди', type: 'text' }
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

  updateTeam(row: Team) {
    this.selectedTeam = row;
    this.showUpdateForm = true;
  }

  deleteTeam(row: Team) {
    this.teamService.delete(row.id).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedTeam) return;

    const command: UpdateTeamCommand = {
      id: this.selectedTeam.id,
      name: updated.name
    };

    this.teamService.update(command).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newTeam: any) {
    const command: AddTeamCommand = {
      name: newTeam.name
    };

    this.teamService.add(command).subscribe({
      next: () => {
        this.refresh();
        this.closeAddForm();
      },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedTeam = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.teamService.getAll().subscribe({
      next: teams => {
        const mapped = teams.map(t => ({
          ...t,
          foremanName: t.foreman?.fullName ?? '',
          masterName: t.master?.fullName ?? '',
          sectionHeadName: t.sectionHead?.fullName ?? '',
          workshopHeadName: t.workshopHead?.fullName ?? '',
          driversNames: t.drivers.map(d => d.fullName).join(', '),
          techniciansNames: t.technicians.map(tc => tc.fullName).join(', ')
        }));
        this.teamsSubject.next(mapped as any);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
