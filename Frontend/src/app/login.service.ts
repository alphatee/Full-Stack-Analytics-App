import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  getUserDetails(username, password){
    return this.http.get('http://localhost:5293/cust/'+username+'/'+password);
  }
}

// currently not using this file