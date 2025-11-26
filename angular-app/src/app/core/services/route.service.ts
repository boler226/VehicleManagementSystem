import {inject, Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AddRouteCommand, UpdateRouteCommand} from '../models/commands/route-commands';
import {Route} from '../models/queries/route-query';

@Injectable({
  providedIn: 'root',
})
export class RouteService {
  private http = inject(HttpClient);
  private baseUrl = 'https://localhost:7011/api/Routes';

  getAll(): Observable<Route[]> {
    return this.http.get<Route[]>(this.baseUrl);
  }

  add(command: AddRouteCommand): Observable<string> {
    return this.http.post<string>(this.baseUrl, command);
  }

  update(command: UpdateRouteCommand): Observable<void> {
    return this.http.put<void>(this.baseUrl, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }
}
