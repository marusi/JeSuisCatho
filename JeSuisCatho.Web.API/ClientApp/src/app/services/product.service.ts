import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly productsEndpoint = '/api/products';


  constructor(private http: HttpClient) { }


  getSuppliers() {
    return this.http.get<any>('/api/suppliers');
  }

  getCategoryItems() {
    return this.http.get<any>('/api/categoryitems');
  }

  getProducts() {
    return this.http.get<any>(this.productsEndpoint);
  }

   getProduct(id) {
        return this.http.get<any>(this.productsEndpoint + '/' + id);
   }

 

  create(product) {
      return this.http.post(this.productsEndpoint, product)

   }
}
