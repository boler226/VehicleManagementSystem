import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {AddPersonCommand, UpdatePersonCommand} from '../../../core/models/commands/person-commands';
import {PersonService} from '../../../core/services/person.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {Person} from '../../../core/models/queries/team-query';
import {DynamicFormComponent} from '../../../shared/forms/dynamic-form/dynamic-form.component';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';
import {FormField} from '../../../core/models/form-config';

@Component({
  selector: 'app-person-grid',
  imports: [
    DynamicFormComponent,
    TableComponent,
    AsyncPipe
  ],
  templateUrl: './person-grid.component.html',
  standalone: true
})
export class PersonGridComponent {
  private personService = inject(PersonService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private personsSubject = new BehaviorSubject<Person[]>([]);
  persons$: Observable<Person[]> = this.personsSubject.asObservable();

  selectedPerson: Person | null = null;
  showUpdateForm = false;
  showAddForm = false;

  columns = [
    { field: 'id', header: '#' },
    { field: 'fullName', header: 'ПІБ' },
    { field: 'position', header: 'Посада' }
  ];

  updateFields: FormField[] = [
    { field: 'fullName', label: 'ПІБ', type: 'text' },
    { field: 'position', label: 'Посада', type: 'text' }
  ];

  addFields: FormField[] = [
    { field: 'fullName', label: 'ПІБ', type: 'text' },
    { field: 'position', label: 'Посада', type: 'text' }
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

  updatePerson(row: Person) {
    this.selectedPerson = row;
    this.showUpdateForm = true;
  }

  deletePerson(row: Person) {
    this.personService.delete(row.id).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  onUpdateSave(updated: any) {
    if (!this.selectedPerson) return;

    const command: UpdatePersonCommand = {
      id: this.selectedPerson.id,
      fullName: updated.fullName,
      position: updated.position
    };

    this.personService.update(command).subscribe({
      next: () => {
        this.refresh();
        this.closeForm();
      },
      error: err => console.error('Помилка при редагуванні', err)
    });
  }

  onAddSave(newPerson: any) {
    const command: AddPersonCommand = {
      fullName: newPerson.fullName,
      position: newPerson.position
    };

    this.personService.add(command).subscribe({
      next: () => {
        this.refresh();
        this.closeAddForm();
      },
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  closeForm() {
    this.showUpdateForm = false;
    this.selectedPerson = null;
    this.cdr.detectChanges();
  }

  private refresh() {
    this.personService.getAll().subscribe({
      next: persons => {
        this.personsSubject.next(persons);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
