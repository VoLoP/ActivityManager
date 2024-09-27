import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ActivityComponent } from "../activity/activity.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ActivityComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'ActivityFront';
}
