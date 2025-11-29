import {Component, inject} from '@angular/core';
import {TransportRepairDto} from '../../../core/models/queries/transport-repair-query';
import {TransportRepairService} from '../../../core/services/transport-repair.service';
import {TableComponent} from '../../../shared/table/table.component';

@Component({
  selector: 'app-transport-repairs-grid',
  imports: [
    TableComponent
  ],
  templateUrl: './transport-repairs-grid.component.html',
  standalone: true
})
export class TransportRepairsGridComponent {
  private repairService = inject(TransportRepairService);

  repairs: TransportRepairDto[] = [];

  columns = [
    { field: 'transport.licensePlate', header: 'Номер' },
    { field: 'transport.brand', header: 'Марка' },
    { field: 'transport.model', header: 'Модель' },
    { field: 'repairDate', header: 'Дата ремонту' },
    { field: 'cost', header: 'Вартість' },
    { field: 'garageObject.name', header: 'Гараж' }
  ];

  constructor() {
    this.loadRepairs();
  }

  loadRepairs() {
    this.repairService.getAll().subscribe({
      next: res => this.repairs = res,
      error: err => console.error('Помилка при отриманні ремонтів', err)
    });
  }
}
