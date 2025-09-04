import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { TripInfoList } from '../shared/_model/tripinfodata';

// Very easy to add this header: 'Content-Type'
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class TripService {
  private apiUrl = environment.apiUrl; // Use environment API URL

  constructor(private http: HttpClient) { }

  getTravelDetails(name?: string, searchQuery?: string, pageNumber = 1, pageSize = 5): Observable<any> {
    let params = new HttpParams()
      .set('pageNumber', pageNumber.toString())
      .set('pageSize', pageSize.toString());

    if (name) {
      params = params.set('name', name);
    }

    if (searchQuery) {
      params = params.set('searchQuery', searchQuery);
    }

    // Use full API URL
    const url = `${this.apiUrl}v1/trips/GetTravelDetails`;
    console.log('TripService API URL:', this.apiUrl); // Debug
    console.log('TripService Full URL:', url); // Debug
    return this.http.get(url, { params, ...httpOptions });
  }

  // this does the same thing as getTravelDetails method
  loadTripData()
  {
    const url = `${this.apiUrl}v1/trips/GetTravelDetails`;

    return this.http.get<TripInfoList>(url);
  }
}
