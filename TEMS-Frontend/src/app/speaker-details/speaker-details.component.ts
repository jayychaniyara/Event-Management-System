import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Speaker } from '../models/speaker';
import { ServiceService } from '../services/service.service';


@Component({
  selector: 'app-speaker-details',
  templateUrl: './speaker-details.component.html',
  styleUrls: ['./speaker-details.component.css']
})
export class SpeakerDetailsComponent implements OnInit {

  listSpeaker: Speaker[] | any = [];
  id: Speaker[] | any = [];
  constructor(public route: ActivatedRoute, public service: ServiceService) { }

  ngOnInit(): void {
    var id = this.route.snapshot.params['id'];
    console.log("id below");
    console.log(id);

    this.speakerDetails(id);
  }

  speakerDetails(id: number) {
    this.service.GetSpeakersOfSpecificEvent(id).subscribe(data => {
      this.listSpeaker = data;
      console.log(data);
    });
  }
}
