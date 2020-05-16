import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';







@Injectable({
  providedIn: 'root'
})

export class MpesaService {

  private readonly authEndpoint = '/api/mpesa-auth';
  


  constructor(
    private http: HttpClient
  ) {

  }

  authMpesa() {
    return this.http.get(this.authEndpoint);
  }

}
