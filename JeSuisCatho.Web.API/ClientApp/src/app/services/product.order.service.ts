import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductOrdersService {

  baseURL: string;

  constructor(private http: HttpClient) {
    this.baseURL = '/api/orders/';
  }

  myOrderDetails(userId: string) {
    return this.http.get(this.baseURL + userId)
      .pipe(map((response: Order[]) => {
        return response;
      }));
  }
}
