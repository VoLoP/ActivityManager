import { AfterContentChecked, AfterContentInit, AfterViewChecked, AfterViewInit, Component, DoCheck, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ActivityComponent } from "../activity/activity.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ActivityComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit, DoCheck, AfterContentInit, AfterContentChecked, AfterViewInit, AfterViewChecked {
  title = 'ActivityFront';

  ngOnInit(): void {
    console.log('AppComponent: ngOnInit');
  }

  ngDoCheck(): void {
    console.log('AppComponent: ngDoCheck');
  }

  ngAfterContentInit(): void {
    console.log('AppComponent: ngAfterContentInit');
  }

  ngAfterContentChecked(): void {
    console.log('AppComponent: ngAfterContentChecked');
  }

  ngAfterViewInit(): void {
    console.log('AppComponent: ngAfterViewInit');
  }

  ngAfterViewChecked(): void {
    console.log('AppComponent: ngAfterViewChecked');
  }
}
