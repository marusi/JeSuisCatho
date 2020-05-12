import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class CheckOutService {

  baseURL: string;

  constructor(private http: HttpClient) {
    this.baseURL = '/api/CheckOut/';
  }

  placeOrder(userId: string, checkedOutItems: Order) {
    return this.http.post(this.baseURL + `${userId}`, checkedOutItems)
      .pipe(map(response => {
        return response;
      }));
  }
}
