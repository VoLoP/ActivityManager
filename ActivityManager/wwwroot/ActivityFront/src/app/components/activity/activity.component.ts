import { Component, OnInit } from '@angular/core';
import { ActivityService } from '../../services/activity.service';
import { Activity } from '../../models/activity.model';
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
  selectedActivity: Activity | null = null;

  constructor(private activityService: ActivityService) {}

  ngOnInit(): void {
    this.activityService.activities$.subscribe(data => {
      this.activities = data;
    });
    this.activityService.loadActivities();
  }

  addActivity(): void {
    this.activityService.create(this.newActivity).subscribe(() => {
      this.newActivity = { id: 0, name: '', date: new Date(), description: '' };
    });
  }

  deleteActivity(id: number): void {
    this.activityService.delete(id).subscribe();
  }

  editActivity(activity: Activity): void {
    this.selectedActivity = { ...activity };
  }

  updateActivity(): void {
    if (this.selectedActivity) {
      this.activityService.update(this.selectedActivity).subscribe(() => {
        this.selectedActivity = null;
      });
    }
  }
}