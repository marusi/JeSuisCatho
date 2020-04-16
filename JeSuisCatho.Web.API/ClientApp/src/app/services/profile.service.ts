import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';








@Injectable({
  providedIn: 'root'
})
export class ProfileService {





  constructor(  private http: HttpClient) { }


  getProfile() {
    return this.http.get<any>('/api/userprofile');
  }



  
}
