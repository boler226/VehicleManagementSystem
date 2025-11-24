import {inject, Injectable} from '@angular/core';
import {Team} from '../models/queries/driver-query';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {AddTeamCommand, UpdateTeamCommand} from '../models/commands/team-commands';

@Injectable({
  providedIn: 'root',
})
export class TeamService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Teams';

  getAll(): Observable<Team[]> {
    return this.http.get<Team[]>(this.apiUrl);
  }

  add(command: AddTeamCommand): Observable<Team> {
    return this.http.post<Team>(this.apiUrl, command);
  }

  update(command: UpdateTeamCommand): Observable<Team> {
    return this.http.put<Team>(this.apiUrl, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
