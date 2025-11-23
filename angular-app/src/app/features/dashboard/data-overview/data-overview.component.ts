import {Component, inject} from '@angular/core';
import {Transport} from '../../../core/models/transport';
import {TableComponent} from '../../../shared/table/table.component';
import {TransportService} from '../../../core/services/transport.service';
import {Observable} from 'rxjs';
import {AsyncPipe} from '@angular/common';

@Component({
  selector: 'app-data-overview',
  imports: [
    TableComponent,
    AsyncPipe
  ],
  templateUrl: './data-overview.component.html',
  standalone: true
})
export class DataOverviewComponent {
  private transportService = inject(TransportService);

  transports$: Observable<Transport[]> = this.transportService.getAll();

  columns = [
    { field: 'id', header: '#' },
    { field: 'licensePlate', header: 'Номерний знак' },
    { field: 'brand', header: 'Марка' },
    { field: 'model', header: 'Модель' },
    { field: 'type', header: 'Тип' },
    { field: 'capacity', header: 'Місткість' },
    { field: 'loadCapacity', header: 'Вантажопідйомність' }
  ];

}
