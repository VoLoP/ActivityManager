import { Component, OnInit } from '@angular/core';
import { ActivityService } from '../../services/activity.service';
import { Activity } from '../../models/activity.model';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from '../app/app.component';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-activity',
  standalone: true,
  imports: [CommonModule, HttpClientModule, AppComponent, FormsModule],
  templateUrl: './activity.component.html',
  styleUrl: './activity.component.scss'
})
export class ActivityComponent implements OnInit {

  activities: Activity[] = [];
  newActivity: Activity = { id: 0, name: '', date: new Date(), description: '' };

  constructor(private activityService: ActivityService) {}

  ngOnInit(): void {
    this.loadActivities();
  }

  loadActivities(): void {
    this.activityService.getAll().subscribe(data => {
      this.activities = data;
    });
  }

  addActivity(): void {
    this.activityService.create(this.newActivity).subscribe(() => {
      this.loadActivities();
      this.newActivity = { id: 0, name: '', date: new Date(), description: '' };
    });
  }

  deleteActivity(id: number): void {
    this.activityService.delete(id).subscribe(() => {
      this.loadActivities();
    });
  }
}
