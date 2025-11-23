import {inject, Injectable} from '@angular/core';
import {Transport} from '../models/transport';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TransportService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Transports';

  getAll(): Observable<Transport[]> {
    return this.http.get<Transport[]>(`${this.apiUrl}`);
  }
}
