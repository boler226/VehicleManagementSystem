import {inject, Injectable} from '@angular/core';
import {GetMileageRecordByDate, MileageRecord} from '../models/queries/mileage-record-query';
import {Observable} from 'rxjs';
import {HttpClient, HttpParams} from '@angular/common/http';
import {AddMileageRecordCommand, UpdateMileageRecordCommand} from '../models/commands/mileage-record-commands';

// noinspection JSAnnotator
@Injectable({
  providedIn: 'root',
})
export class MileageRecordService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/MileageRecords';

  getAll(): Observable<MileageRecord[]> {
    return this.http.get<MileageRecord[]>(`${this.apiUrl}`);
  }

  getRecords(query: GetMileageRecordByDate): Observable<MileageRecord[]> {
    let params = new HttpParams().set('date', query.date);
    if (query.category) params = params.set('category', query.category);
    if (query.transportId) params = params.set('transportId', query.transportId);

    return this.http.get<MileageRecord[]>(`${this.apiUrl}/milieage-records`, { params });
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
