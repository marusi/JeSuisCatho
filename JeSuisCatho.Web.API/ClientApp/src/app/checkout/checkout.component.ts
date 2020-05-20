import { Component, OnInit, OnDestroy } from '@angular/core';
import { Order } from '../models/order';
import { Profile } from '../models/profile';
import { ProfileService } from '../services/profile.service';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CartService } from '../services/cart.service';
import { CheckOutService } from '../services/checkout.service';
import { ShoppingCart } from '../models/shoppingcart';
import { SnackbarService } from '../services/snackbar.service';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})

export class CheckOutComponent implements OnInit, OnDestroy {

  userId;
  totalPrice: number;
  wordItem = 'item';
  cartCountWord;
  checkOutItems = new Order();
  private unsubscribe$ = new Subject<void>();
  profile: Profile = {
    id: '',
    email: '',
    cartCount: 0,
    name: '',
    isLoggedIn: true
  };

  constructor(
    private userService: ProfileService,
     private fb: FormBuilder,
    private router: Router,
    private cartService: CartService,
   
    private checkOutService: CheckOutService,
    private snackBarService: SnackbarService) {

    this.userService.getProfile().subscribe(profile => {
      this.profile = profile;
      this.profile.cartCount = profile.cartCount;
      this.cartCountWord = this.pluralize(this.profile.cartCount, `${this.wordItem}`);

    

    }, error => console.log(error));
    this.userId = localStorage.getItem('id');
  }

  checkOutForm = this.fb.group({
    name: ['', Validators.required],
    addressLine1: ['', Validators.required],
    addressLine2: ['', Validators.required],
    pincode: ['', Validators.compose([Validators.required, Validators.pattern('^[1-9][0-9]{5}$')])],
    state: ['', [Validators.required]]
  });

  get name() {
    return this.checkOutForm.get('name');
  }

  get addressLine1() {
    return this.checkOutForm.get('addressLine1');
  }

  get addressLine2() {
    return this.checkOutForm.get('addressLine2');
  }

  get pincode() {
    return this.checkOutForm.get('pincode');
  }
  get state() {
    return this.checkOutForm.get('state');
  }

  ngOnInit() {
    this.getCheckOutItems();
  }

  getCheckOutItems() {
    this.cartService.getCartItems(this.userId)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (result: ShoppingCart[]) => {
          this.checkOutItems.orderDetails = result;
          this.getTotalPrice();
        }, error => {
          console.log('Error ocurred while fetching shopping cart item : ', error);
        });
  }

  getTotalPrice() {
    this.totalPrice = 0;
    this.checkOutItems.orderDetails.forEach(item => {
      this.totalPrice += (item.product.sellUnitPrice  * item.quantity);
    });
    this.checkOutItems.cartTotal = this.totalPrice;
  }

  placeOrder() {
    if (this.checkOutForm.valid) {
      this.checkOutService.placeOrder(this.userId, this.checkOutItems)
        .pipe(takeUntil(this.unsubscribe$))
        .subscribe(
          result => {
            this.userService.cartItemcount$.next(result);
            this.router.navigate(['/myorders']);
            this.snackBarService.showSnackBar('Order placed successfully!!!');
          }, error => {
            console.log('Error ocurred while placing order : ', error);
          });
    }
  }
  pluralize = (count, noun, suffix = 's') => `${noun}${count !== 1 ? suffix : ''}`;
  ngOnDestroy() {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
