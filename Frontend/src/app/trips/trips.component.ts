import { Component, OnInit } from '@angular/core';
import { TripService } from '../services/trip.service';
import { CommonModule, JsonPipe } from '@angular/common';

@Component({
  selector: 'trips',
  standalone: true,
  imports: [CommonModule, JsonPipe],
  templateUrl: './trips.component.html',
  styleUrls: ['./trips.component.css']
})
export class TripsComponent implements OnInit {
  trips: any[] = [];

  constructor(private tripService: TripService) { }

  ngOnInit() {
    this.tripService.getTravelDetails().subscribe(
      data => {
        this.trips = data; // Directly assign the data if you're not observing the full response
      },
      error => {
        console.error('Error fetching travel details:', error);
      }
    );
  }
}
