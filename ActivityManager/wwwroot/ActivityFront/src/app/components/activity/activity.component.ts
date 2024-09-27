import { Component, OnInit } from '@angular/core';
import { ActivityService } from '../../services/activity.service';
import { Activity } from '../../models/activity.model';

@Component({
  selector: 'app-activity',
  standalone: true,
  imports: [],
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
