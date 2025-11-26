import {Component, inject} from '@angular/core';
import {TableColumn} from '../../../../core/models/table-config';
import {CargoTransportReportDto, Transport} from '../../../../core/models/queries/transport-query';
import {TransportService} from '../../../../core/services/transport.service';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-cargo-report-grid',
  imports: [
    FormsModule
  ],
  templateUrl: './cargo-report-grid.component.html',
  standalone: true
})
export class CargoReportGridComponent {
  private transportService = inject(TransportService);

  selectedId: string = '';
  fromDate: string = '';
  toDate: string = ''

  showForm = true;
  report: CargoTransportReportDto | null = null;
  transports: Transport[] = [];

  columns: TableColumn[] = [
    { field: 'licensePlate', header: 'Номер' },
    { field: 'brand', header: 'Марка' },
    { field: 'model', header: 'Модель' },
    { field: 'loadCapacity', header: 'Вантажопідйомність' },
    { field: 'tripsCount', header: 'Кількість рейсів' },
    { field: 'totalCargoWeight', header: 'Загальна вага' },
    { field: 'fromDate', header: 'Від' },
    { field: 'toDate', header: 'До' }
  ];

  constructor() {
    this.transportService.getAll().subscribe({
      next: (res: Transport[]) => {
        this.transports = res;
      },
      error: err => console.error('Помилка при завантаженні транспорту', err)
    });
  }

  onFormSave() {
    this.transportService.getCargoReport(this.selectedId, this.fromDate, this.toDate).subscribe({
      next: res => {
        this.report = res;
        this.showForm = false;
      },
      error: err => console.error('Помилка при отриманні звіту', err)
    });
  }

  openFormAgain() {
    this.showForm = true;
    this.report = null;
  }
}
