import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SubscriptionService } from './subscription.service';
import { ProfileService } from './profile.service';
import { Profile } from '../models/profile';


// import { tokenNotExpired } from 'angular2-jwt';


@Injectable({
  providedIn: 'root'
})

export class AuthService implements OnInit {
  profile: Profile;
  oldUserId;
  //Constants
  private readonly registerEndpoint = '/api/auth/register';
  private readonly loginEndpoint = '/api/auth/login';
 

  constructor(
    private http: HttpClient,
    private profileService: ProfileService,

    private subscriptionService: SubscriptionService
  ) {
    
  }

  ngOnInit(): void {

  

    // this.auth.tryFunct();
  }
  create(account) {
    return this.http.post(this.registerEndpoint, account);
  }
  login(account) {
    return this.http.post(this.loginEndpoint, account)
  
    
  }




  logout() {

    localStorage.removeItem('token');
  }
  getToken() {
    return localStorage.getItem('token');
  }

  public authenticated(token) {
    // Check if there's an unexpired JWT
    // This searches for an item in localStorage with key == 'token'
    if (this.tokenExpired(token)) {
      console.log("token expired")
     return false
      // token expired
    } else {
      // token valid
      console.log("token valid")


      return true
    }

  }

  public notAuthenticated() {
    // Check if there's an unexpired JWT
    // This searches for an item in localStorage with key == 'token'
    if (localStorage.getItem("token") === null) {
      console.log("not signed in");
      return true
    } 

  }

 

  private tokenExpired(token: string) {
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
  }

  tryFunct() {
    this.authenticated(this.getToken())
  }


  

}
