import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  url: string = "https://localhost:7288";

  constructor(private http: HttpClient) { }

  getCompletedEvents(): Observable<any[]> {
    return this.http.get<any[]>(this.url + '/events/completed');
  }

  getCompletedEventsById(id: number) {
    return this.http.get(this.url + `/events/${id}`);
  }

  getEventByCurrentMonth(month: number) {
    return this.http.get(this.url + `/events/${month}`);
  }

  GetCompletedTalksBySpecificSpeaker(Eventid: number, Speakerid: number) {
    return this.http.get(this.url + `/events/${Eventid}/authors/${Speakerid}`);
  }

  GetSpeakersOfSpecificEvent(id: number) {
    return this.http.get(this.url + `/events/${id}/authors`);
  }

  GetTalkOfSpeakerForEvent(Eventid: number, Speakerid: number) {
    return this.http.get(this.url + `/events/${Eventid}/authors/${Speakerid}/talks`);
  }

  GetSpeakerById(id: number) {
    return this.http.get(this.url + `/speaker/${id}`);
  }

  GetAllVenueOfEventById(id: number) {
    return this.http.get(this.url + `/events/${id}/venues`);
  }

  GetSpecificVenueDetail(Eventid: number, Cityid: number) {
    return this.http.get(this.url + `/events/${Eventid}/venues/${Cityid}`);
  }
}
