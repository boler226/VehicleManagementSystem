import {Component, inject} from '@angular/core';
import {TableColumn} from '../../../../core/models/table-config';
import {GarageObjectStatisticsDto} from '../../../../core/models/queries/garage-object-query';
import {GarageObjectService} from '../../../../core/services/garage-object.service';
import {TableComponent} from '../../../../shared/table/table.component';
import {KeyValuePipe} from '@angular/common';

@Component({
  selector: 'app-garage-statistics-grid',
  imports: [
    TableComponent,
    KeyValuePipe
  ],
  templateUrl: './garage-statistics-grid.component.html',
  standalone: true
})
export class GarageStatisticsGridComponent {
  private garageService = inject(GarageObjectService);

  garages: GarageObjectStatisticsDto[] = [];

  columns: TableColumn[] = [
    { field: 'name', header: 'Гараж' },
    { field: 'totalVehicles', header: 'Всього транспорту' }
  ];

  constructor() {
    this.garageService.getGarageStatistics().subscribe({
      next: res => this.garages = res,
      error: err => console.error('Помилка при отриманні статистики', err)
    });
  }
}
