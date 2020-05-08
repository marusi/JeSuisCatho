import { Component, OnInit, OnDestroy } from '@angular/core';
import { ShoppingCart } from '../models/shoppingcart';
import { CartService } from '../services/cart.service';
import { SnackbarService } from '../services/snackbar.service';
import { ProfileService } from '../services/profile.service';
import { Profile } from '../models/profile';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-shoppingcart',
  templateUrl: './shoppingcart.component.html',
  styleUrls: ['./shoppingcart.component.css']
})
export class ShoppingCartComponent implements OnInit, OnDestroy {
  public cartItems: ShoppingCart[];
  profile: Profile;
  userId;
  totalPrice: number;
  private unsubscribe$ = new Subject<void>();

  constructor(
    private cartService: CartService,
    private snackBarService: SnackbarService,
    private userService: ProfileService) {
    this.userService.getProfile().subscribe(profile => {

      this.profile = profile;
      // console.log(`PROF: ${this.profile.id}`);
      this.userId = this.profile.id;
    }, error => console.log(error));
  }

  ngOnInit() {
    this.cartItems = [];
    this.cartService.getOldCart();
    this.getShoppingCartItems();
  }

  getShoppingCartItems() {
    this.cartService.getCartItems(this.userId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (result: ShoppingCart[]) => {
          this.cartItems = result;
          this.getTotalPrice();
        }, error => {
          console.log('Error ocurred while fetching shopping cart item : ', error);
        });
  }

  getTotalPrice() {
    this.totalPrice = 0;
    this.cartItems.forEach(item => {
   
      this.totalPrice += (item.product.sell.unitPrice * item.quantity);
    });
  }

  deleteCartItem(productId: number) {
    this.cartService.removeCartItems(this.userId, productId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        result => {
          this.userService.cartItemcount$.next(result);
          this.snackBarService.showSnackBar('Product removed from cart');
          this.getShoppingCartItems();
        }, error => {
          console.log('Error ocurred while deleting cart item : ', error);
        });
  }

  addToCart(productId: number) {
    this.cartService.addProductToCart(this.userId, productId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        result => {
          this.userService.cartItemcount$.next(result);
          this.snackBarService.showSnackBar('One item added to cart');
          this.getShoppingCartItems();
        }, error => {
          console.log('Error ocurred while addToCart data : ', error);
        });
  }

  deleteOneCartItem(productId: number) {
    this.cartService.deleteOneCartItem(this.userId, productId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        result => {
          this.userService.cartItemcount$.next(result);
          this.snackBarService.showSnackBar('One item removed from cart');
          this.getShoppingCartItems();
        }, error => {
          console.log('Error ocurred while fetching book data : ', error);
        });
  }

  clearCart() {
    this.cartService.clearCart(this.userId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        result => {
          this.userService.cartItemcount$.next(result);
          this.snackBarService.showSnackBar('Cart cleared!!!');
          this.getShoppingCartItems();
        }, error => {
          console.log('Error ocurred while deleting cart item : ', error);
        });
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
