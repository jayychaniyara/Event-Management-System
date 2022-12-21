import { Component, OnInit } from '@angular/core';
import { ServiceService } from '../services/service.service';
import { Event } from '../models/event';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  listEvent: Event[] | any = [];

  constructor(public service: ServiceService) { }

  ngOnInit(): void {
    this.service.getCompletedEvents().subscribe(data => {
      this.listEvent = data;
    });
  }
}
