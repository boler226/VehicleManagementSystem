import {inject, Injectable} from '@angular/core';
import {CargoTransportReportDto, Transport} from '../models/queries/transport-query';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AddTransportCommand, UpdateTransportCommand} from '../models/commands/transport-commands';

@Injectable({
  providedIn: 'root',
})
export class TransportService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Transports';

  getAll(): Observable<Transport[]> {
    return this.http.get<Transport[]>(`${this.apiUrl}`);
  }

  getCargoReport(id: string, fromDate: string, toDate: string): Observable<CargoTransportReportDto> {
    return this.http.get<CargoTransportReportDto>(
      `https://localhost:7011/api/Transports/cargo-report`,
      {
        params: {
          Id: id,
          FromDate: fromDate,
          ToDate: toDate
        }
      }
    );
  }

  add(command: AddTransportCommand): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}`, command);
  }

  update(command: UpdateTransportCommand): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}`, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
