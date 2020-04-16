import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';








@Injectable({
  providedIn: 'root'
})
export class InquiryService {


  private readonly inquiryEndpoint = '/api/v1/requestapply';

  private readonly visitEndpoint = '/api/v1/visits';
 

  constructor(private http: HttpClient) { }


 

  getLocations() {
    return this.http.get<any>('/api/v1/locations');
  }

  create(inquiry) {
    return this.http.post(this.inquiryEndpoint, inquiry)

  }

  getInquiry(id) {
    return this.http.get<any>(this.inquiryEndpoint + '/' + id);
  }

  getVisit(id) {
    return this.http.get<any>(this.visitEndpoint + '/' + id);
  }

  createVisit(visit) {
    return this.http.post(this.visitEndpoint, visit)
  }

}
