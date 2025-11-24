import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {Technician} from '../models/queries/technician-query';
import {AddTechnicianCommand, UpdateTechnicianCommand} from '../models/commands/technician-commands';

@Injectable({
  providedIn: 'root',
})
export class TechnicianService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Technicians';

  getAll(): Observable<Technician[]> {
    return this.http.get<Technician[]>(this.apiUrl);
  }

  add(command: AddTechnicianCommand): Observable<Technician> {
    return this.http.post<Technician>(this.apiUrl, command);
  }

  update(command: UpdateTechnicianCommand): Observable<Technician> {
    return this.http.put<Technician>(this.apiUrl, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
