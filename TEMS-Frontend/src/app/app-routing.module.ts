import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './events/events.component';
import { HomePageComponent } from './home-page/home-page.component';
import { SpeakerDetailsComponent } from './speaker-details/speaker-details.component';
import { VenueDetailsComponent } from './venue-details/venue-details.component';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'speakerDetails/:id', component: SpeakerDetailsComponent },
  { path: 'venueDetails/:id', component: VenueDetailsComponent },
  { path: 'eventDetails', component: EventsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
