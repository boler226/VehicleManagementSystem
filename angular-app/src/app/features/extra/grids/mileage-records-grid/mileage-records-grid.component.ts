import {Component, inject} from '@angular/core';
import {MileageRecord} from '../../../../core/models/queries/mileage-record-query';
import {MileageRecordService} from '../../../../core/services/mileage-record.service';
import {TableComponent} from '../../../../shared/table/table.component';
import {FormsModule} from '@angular/forms';
import {TransportService} from '../../../../core/services/transport.service';
import {Transport} from '../../../../core/models/queries/transport-query';

@Component({
  selector: 'app-mileage-records-by-date-grid',
  imports: [
    TableComponent,
    FormsModule
  ],
  templateUrl: './mileage-records-grid.component.html',
  standalone: true
})
export class MileageRecordsByDateGridComponent {
  private mileageService = inject(MileageRecordService);
  private transportService = inject(TransportService);

  date: string = '';
  category: string = '';
  transportId: string = '';

  records: MileageRecord[] = [];
  transports: Transport[] = [];

  columns = [
    { field: 'transport.licensePlate', header: 'Номер' },
    { field: 'transport.brand', header: 'Марка' },
    { field: 'transport.model', header: 'Модель' },
    { field: 'transport.type', header: 'Тип' },
    { field: 'date', header: 'Дата' },
    { field: 'kilometers', header: 'Кілометри' }
  ];

  constructor() {
    this.transportService.getAll().subscribe({
      next: res => this.transports = res,
      error: err => console.error('Помилка при завантаженні транспорту', err)
    });
  }

  loadRecords() {
    this.mileageService.getRecords({
      date: this.date,
      category: this.category || null,
      transportId: this.transportId || null
    }).subscribe({
      next: res => this.records = res,
      error: err => console.error('Помилка при отриманні пробігу', err)
    });
  }
}
