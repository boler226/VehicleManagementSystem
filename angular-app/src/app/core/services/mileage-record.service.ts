import {inject, Injectable} from '@angular/core';
import {MileageRecord} from '../models/queries/mileage-record-query';
import {Observable} from 'rxjs';
import {HttpClient} from '@angular/common/http';
import {AddMileageRecordCommand, UpdateMileageRecordCommand} from '../models/commands/mileage-record-commands';

@Injectable({
  providedIn: 'root',
})
export class MileageRecordService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/MileageRecords';

  getAll(): Observable<MileageRecord[]> {
    return this.http.get<MileageRecord[]>(`${this.apiUrl}`);
  }

  add(command: AddMileageRecordCommand): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}`, command);
  }

  update(command: UpdateMileageRecordCommand): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}`, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
