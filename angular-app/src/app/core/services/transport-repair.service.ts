import {inject, Injectable} from '@angular/core';
import {TransportRepairDto} from '../models/queries/transport-repair-query';
import {AddTransportRepairCommand, UpdateTransportRepairCommand} from '../models/commands/transport-repair-commands';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransportRepairService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/TransportRepairs';

  getAll(): Observable<TransportRepairDto[]> {
    return this.http.get<TransportRepairDto[]>(this.apiUrl);
  }

  add(command: AddTransportRepairCommand): Observable<string> {
    return this.http.post<string>(this.apiUrl, command);
  }

  update(command: UpdateTransportRepairCommand): Observable<void> {
    return this.http.put<void>(this.apiUrl, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
