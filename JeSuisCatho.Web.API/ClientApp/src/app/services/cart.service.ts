import { Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';''
import { map } from 'rxjs/operators';
import { ShoppingCart } from '../models/shoppingcart';
import { Profile } from '../models/profile';
import { ProfileService } from '../services/profile.service';

@Injectable({
  providedIn: 'root'
})
export class CartService {

 
  baseURL: string;
  profile: Profile;
  cartItemCount: number;
  constructor(private http: HttpClient, private prof: ProfileService,) {
    this.baseURL = '/api/cart/';
     
   
  }

  addProductToCart(userId: string, productId: number) {
    return this.http.post(this.baseURL + `addToCart/${userId}/${productId}`, {})
      .pipe(map(response => {
        return response;
      }));
  }
  getOldCart() {
    this.prof.getProfile().subscribe(profile => {

      this.profile = profile;
      this.cartItemCount = this.profile.cartCount;
      this.prof.cartItemcount$.next(this.profile.cartCount);
    }, error => console.log(error));
  }


  getCartItems(userId: string) {
    return this.http.get(this.baseURL + userId)
      .pipe(map((response: ShoppingCart[]) => {
        this.cartItemCount = response.length;
        return response;
      }));
  }

  removeCartItems(userId: string, productId: number) {
    return this.http.delete(this.baseURL + `${userId}/${productId}`, {})
      .pipe(map(response => {
        return response;
      }));
  }

  deleteOneCartItem(userId: string, productId: number) {
    return this.http.put(this.baseURL + `${userId}/${productId}`, {})
      .pipe(map(response => {
        return response;
      }));
  }

  clearCart(userId: string) {
    return this.http.delete(this.baseURL + `${userId}`, {})
      .pipe(map(response => {
        return response;
      }));
  }

  setCart(oldUserId: string, newUserId: string) {
    return this.http.get(this.baseURL + `setshoppingcart/${oldUserId}/${newUserId}`, {})
      .pipe(map((response: any) => {
        this.cartItemCount = response;
        return response;
      }));
  }
}
