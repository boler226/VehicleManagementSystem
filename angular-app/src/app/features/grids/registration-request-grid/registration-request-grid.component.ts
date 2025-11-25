import {ChangeDetectorRef, Component, inject} from '@angular/core';
import {RegistrationRequest} from '../../../core/models/queries/registration-request-query';
import {RegistrationRequestService} from '../../../core/services/registration-request.service';
import {RoleService} from '../../../core/services/role.service';
import {BehaviorSubject, Observable} from 'rxjs';
import {TableComponent} from '../../../shared/table/table.component';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-registration-request-grid',
  imports: [
    TableComponent,
    AsyncPipe
  ],
  templateUrl: './registration-request-grid.component.html',
  standalone: true
})
export class RegistrationRequestGridComponent {
  private requestService = inject(RegistrationRequestService);
  private roleService = inject(RoleService);
  private cdr = inject(ChangeDetectorRef);

  private requestsSubject = new BehaviorSubject<RegistrationRequest[]>([]);
  requests$: Observable<RegistrationRequest[]> = this.requestsSubject.asObservable();

  columns = [
    { field: 'id', header: '#' },
    { field: 'email', header: 'Email' },
    { field: 'fullName', header: 'ПІБ' },
    { field: 'status', header: 'Статус' },
    { field: 'createdAt', header: 'Дата створення' }
  ];

  constructor() {
    this.refresh();
  }

  approveRequest(row: RegistrationRequest) {
    this.requestService.approve(row.id).subscribe({
      next: () => {
        this.refresh();
      },
      error: err => console.error('Помилка при схваленні', err)
    });
  }

  rejectRequest(row: RegistrationRequest) {
    this.requestService.reject(row.id).subscribe({
      next: () => {
        this.refresh();
      },
      error: err => console.error('Помилка при відхиленні', err)
    });
  }

  private refresh() {
    this.requestService.getAll().subscribe({
      next: requests => {
        const mapped = requests.map(r => ({
          ...r,
          status: r.status ?? 'Pending'
        }));
        this.requestsSubject.next(mapped as any);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  get canCrud(): boolean {
    return this.roleService.hasCrudAccess();
  }
}
