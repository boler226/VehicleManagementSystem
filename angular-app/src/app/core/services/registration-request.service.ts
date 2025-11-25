import {inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {RegistrationRequest} from '../models/queries/registration-request-query';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class RegistrationRequestService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/RegistrationRequest';

  getAll(): Observable<RegistrationRequest[]> {
    return this.http.get<RegistrationRequest[]>(`${this.apiUrl}/registration-requests`);
  }

  approve(requestId: string): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}/${requestId}/approve-registration`, {});
  }

  reject(requestId: string): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/${requestId}/reject-registration`, {});
  }
}
