import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Cities } from '../models/cities';
import { ServiceService } from '../services/service.service';

@Component({
  selector: 'app-venue-details',
  templateUrl: './venue-details.component.html',
  styleUrls: ['./venue-details.component.css']
})
export class VenueDetailsComponent implements OnInit {

  listVenue: Cities[] | any = [];

  constructor(public route: ActivatedRoute, public service: ServiceService) { }

  ngOnInit(): void {
    var id = this.route.snapshot.params['id'];
    this.venueDetails(id);
  }

  venueDetails(id: number) {
    this.service.GetAllVenueOfEventById(id).subscribe(data => {
      this.listVenue = data;
      console.log(data);
    });
  }

}
