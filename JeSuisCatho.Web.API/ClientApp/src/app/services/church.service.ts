import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';








@Injectable({
  providedIn: 'root'
})
export class ChurchService {





  constructor(  private http: HttpClient) { }


  getArchDioceses() {
    return this.http.get<any>('/api/archdioceses');
  }

  getDivisions() {
    return this.http.get<any>('/api/divisions');
  }

  getCounties() {
    return this.http.get<any>('/api/counties');
  }

  
}
