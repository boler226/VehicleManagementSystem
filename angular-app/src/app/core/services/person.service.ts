import {inject, Injectable} from '@angular/core';
import {Observable} from 'rxjs';
import {Person} from '../models/queries/team-query';
import {HttpClient} from '@angular/common/http';
import {AddPersonCommand, UpdatePersonCommand} from '../models/commands/person-commands';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7011/api/Persons';

  getAll(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.apiUrl}`);
  }

  add(command: AddPersonCommand): Observable<string> {
    return this.http.post<string>(`${this.apiUrl}`, command);
  }

  update(command: UpdatePersonCommand): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}`, command);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
