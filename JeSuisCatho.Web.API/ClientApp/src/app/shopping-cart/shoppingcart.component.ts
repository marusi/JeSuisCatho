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
  profile: Profile = {
    id: '',
    email: '',
    cartCount: 0,
    name: '',
    isLoggedIn: true
  };

  
  userId;
  // BUG FIX to enable storage of userID from profile ID
  uniqueID;

  wordItem = 'item';  
  cartCountWord;

  totalPrice: number;
  private unsubscribe$ = new Subject<void>();

  constructor(
    private cartService: CartService,
    private snackBarService: SnackbarService,
    private userService: ProfileService) {
      // BUG FIX to enable storage of userID from profile ID
    this.userService.getProfile().subscribe(profile => {
      this.profile = profile;
      this.cartCountWord = this.pluralize(this.profile.cartCount, `${this.wordItem}`);
     
     for (const [key, value] of Object.entries(profile)) {

        if (key === "id") {
          this.uniqueID = value;
          localStorage.setItem('id', this.uniqueID);

        }
      } 

    }, error => console.log(error));
    this.userId = localStorage.getItem('id');

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
          console.log(this.cartItems);
          
          this.getTotalPrice();
        }, error => {
          console.log('Error ocurred while fetching shopping cart item : ', error);
        });
  }

  getTotalPrice() {
    this.totalPrice = 0;
    this.cartItems.forEach(item => {
      // ERROR reported coz model is not correct.... logic works though
      this.totalPrice += (item.product.sellUnitPrice * item.quantity);
      
    });
  }

 

  pluralize = (count, noun, suffix = 's') => `${noun}${count !== 1 ? suffix : ''}` ;



  deleteCartItem(productId: number) {
    this.cartService.removeCartItems(this.userId, productId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        result => {
          this.userService.cartItemcount$.next(result);
          this.snackBarService.showSnackBar('Product removed from cart');
          this.getShoppingCartItems();
          this.userService.getProfile().subscribe(profile => {
            this.profile = profile;
            this.cartCountWord = this.pluralize(this.profile.cartCount, `${this.wordItem}`);

            

          }, error => console.log(error));
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
          this.profile.cartCount += 1;
          this.cartCountWord = this.pluralize(this.profile.cartCount, `${this.wordItem}`);
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
          this.profile.cartCount -= 1;
          this.cartCountWord = this.pluralize(this.profile.cartCount, `${this.wordItem}`);
        }, error => {
          console.log('Error ocurred while fetching product data : ', error);
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
          this.userService.cartItemcount$.next(result);
          this.profile.cartCount = 0;
        }, error => {
          console.log('Error ocurred while deleting cart item : ', error);
        });
  }

  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
