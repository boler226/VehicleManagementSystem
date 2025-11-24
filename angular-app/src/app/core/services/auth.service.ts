import {inject, Injectable} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {Observable, tap} from 'rxjs';
import {User} from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Auth';

  login(email: string, password: string): Observable<string> {
    return this.http
      .post(`${this.apiUrl}/login`, { email, password }, { responseType: 'text' })
      .pipe(
        tap(token => {
          localStorage.setItem('authToken', token);
        })
      );
  }
  register(user: User): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, user);
  }

  logout() {
    localStorage.removeItem('authToken');
  }

  getToken(): string | null {
    return localStorage.getItem('authToken');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }
}
