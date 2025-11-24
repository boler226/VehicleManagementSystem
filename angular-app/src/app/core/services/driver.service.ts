import {inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {AddDriverCommand, UpdateDriverCommand} from '../models/commands/driver-commands';
import {Driver} from '../models/queries/driver-query';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class DriverService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Drivers';

  getAll(): Observable<Driver[]> {
    return this.http.get<Driver[]>(`${this.apiUrl}`);
  }

  add(command: AddDriverCommand): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}`, command);
  }

  update(command: UpdateDriverCommand): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}`, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
