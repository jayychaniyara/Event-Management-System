import { Component, OnInit } from '@angular/core';
import {  Location } from '@angular/common';

import { Event } from '../models/event';
import { Router } from '@angular/router';
@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  listEvent: Event = new Event();
  constructor(private location: Location, public router: Router) { }

  ngOnInit(): void {

    this.listEvent = this.location.getState() as Event;
    this.listEvent.id = this.location.getState() as Event["id"];

  }

  getDiffDays(listEvent: Event) {
    var startDate = new Date(this.listEvent.startDate);
    var endDate = new Date(this.listEvent.endDate);
    var Time = endDate.getTime() - startDate.getTime();
    return (Time / (1000 * 3600 * 24)) + 1;
  }

  redirectSpeakers() {
    this.router.navigate([`speakerDetails/${this.listEvent.speakerId}`]);
  }

  redirectVenue() {
    this.router.navigate([`venueDetails/${this.listEvent.cityId}`]);
  }
}
