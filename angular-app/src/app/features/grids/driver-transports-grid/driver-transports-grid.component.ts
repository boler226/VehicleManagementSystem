import {Component, inject} from '@angular/core';
import {DriverTransportService} from '../../../core/services/driver-transport.service';
import {DriverService} from '../../../core/services/driver.service';
import {TransportService} from '../../../core/services/transport.service';
import {BehaviorSubject, forkJoin, Observable} from 'rxjs';
import {AsyncPipe} from '@angular/common';
import {Transport} from '../../../core/models/queries/transport-query';
import {Driver} from '../../../core/models/queries/driver-query';

@Component({
  selector: 'app-driver-transports-grid',
  imports: [
    AsyncPipe
  ],
  templateUrl: './driver-transports-grid.component.html',
  standalone: true
})
export class DriverTransportsGridComponent {
  private driverService = inject(DriverService);
  private transportService = inject(TransportService);
  private driverTransportService = inject(DriverTransportService);

  private driversSubject = new BehaviorSubject<Driver[]>([]);
  drivers$: Observable<Driver[]> = this.driversSubject.asObservable();

  private transportsSubject = new BehaviorSubject<Transport[]>([]);
  transports$: Observable<Transport[]> = this.transportsSubject.asObservable();

  selectedDriver: Driver | null = null;
  selectedTransport: Transport | null = null;

  constructor() {
    this.refresh();
  }

  private refresh() {
    forkJoin({
      drivers: this.driverService.getAll(),
      transports: this.transportService.getAll()
    }).subscribe({
      next: ({ drivers, transports }) => {
        this.driversSubject.next(drivers);
        this.transportsSubject.next(transports);
      },
      error: err => console.error('Помилка при завантаженні', err)
    });
  }

  addLink() {
    if (!this.selectedDriver || !this.selectedTransport) return;

    this.driverTransportService.add({
      driverId: this.selectedDriver.id,
      transportId: this.selectedTransport.id
    }).subscribe({
      next: () => this.refresh(),
      error: err => console.error('Помилка при додаванні', err)
    });
  }

  deleteLink() {
    if (!this.selectedDriver || !this.selectedTransport) return;

    this.driverTransportService.delete(this.selectedDriver.id, this.selectedTransport.id).subscribe({
      next: () => this.refresh(),
      error: err => console.error('Помилка при видаленні', err)
    });
  }

  selectDriver(driver: Driver) {
    this.selectedDriver = driver;
  }

  selectTransport(transport: Transport) {
    this.selectedTransport = transport;
  }
}
