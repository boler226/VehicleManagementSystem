import {inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {GarageObject, GarageObjectStatisticsDto} from '../models/queries/garage-object-query';
import {AddGarageObjectCommand, UpdateGarageObjectCommand} from '../models/commands/garage-object-commands';

@Injectable({
  providedIn: 'root',
})
export class GarageObjectService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/GarageObjects';

  getAll(): Observable<GarageObject[]> {
    return this.http.get<GarageObject[]>(this.apiUrl);
  }

  getGarageStatistics(): Observable<GarageObjectStatisticsDto[]> {
    return this.http.get<GarageObjectStatisticsDto[]>(
      `${this.apiUrl}/statistics`
    );
  }

  add(command: AddGarageObjectCommand): Observable<string> {
    return this.http.post<string>(this.apiUrl, command);
  }

  update(command: UpdateGarageObjectCommand): Observable<void> {
    const normalized: UpdateGarageObjectCommand = {
      id: command.id,
      name: command.name === '' ? null : command.name,
      location: command.location === '' ? null : command.location
    };
    return this.http.put<void>(this.apiUrl, normalized);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
