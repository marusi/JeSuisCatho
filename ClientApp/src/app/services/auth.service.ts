import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private readonly registerEndpoint = '/api/auth/register';
  private readonly loginEndpoint = '/api/auth/login';

  constructor(private http: HttpClient) { }

  create(account) {
    return this.http.post(this.registerEndpoint, account);
  }
  login(account) {
    return this.http.post(this.loginEndpoint, account);
  }

  logout() {

    localStorage.removeItem('token');
  }
  getToken() {
    return localStorage.getItem('token');
  }
}
