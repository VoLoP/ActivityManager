import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Activity } from '../models/activity.model';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'any'
})
export class ActivityService {

  private apiUrl = 'http://localhost:5112/api/activity';
  private activitiesSubject = new BehaviorSubject<Activity[]>([]);
  public activities$ = this.activitiesSubject.asObservable();

  constructor(private http: HttpClient) { }

  loadActivities(): void {
    this.http.get<Activity[]>(this.apiUrl).subscribe(data => {
      this.activitiesSubject.next(data);
    });
  }

  getById(id: number): Observable<Activity> {
    return this.http.get<Activity>(`${this.apiUrl}/${id}`);
  }

  create(activity: Activity): Observable<Activity> {
    return this.http.post<Activity>(this.apiUrl, activity).pipe(
      tap(() => this.loadActivities())
    );
  }

  update(activity: Activity): Observable<void> {
    return this.http.put<void>(this.apiUrl, activity).pipe(
      tap(() => this.loadActivities())
    );
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`).pipe(
      tap(() => this.loadActivities())
    );
  }
}