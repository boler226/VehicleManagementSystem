import {inject, Injectable} from '@angular/core';
import {AddDriverTransportCommand, DeleteDriverTransportCommand} from '../models/commands/driver-transport-commands';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DriverTransportService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/DriverTransports';

  add(command: AddDriverTransportCommand): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}`, command);
  }

  delete(driverId: string, transportId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${driverId}/${transportId}`);
  }
}
