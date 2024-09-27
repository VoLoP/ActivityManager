import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Activity } from '../models/activity.model';

@Injectable({
  providedIn: 'any'
})
export class ActivityService {

  private apiUrl = 'https://localhost:5001/api/activity';

  constructor(private http: HttpClient) { }

getAll(): Observable<Activity[]> {
    return this.http.get<Activity[]>(this.apiUrl);
  }

  getById(id: number): Observable<Activity> {
    return this.http.get<Activity>(`${this.apiUrl}/${id}`);
  }

  create(activity: Activity): Observable<Activity> {
    return this.http.post<Activity>(this.apiUrl, activity);
  }

  update(activity: Activity): Observable<void> {
    return this.http.put<void>(this.apiUrl, activity);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}