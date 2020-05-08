import { Component, Input } from '@angular/core';
import { CartService } from '../services/cart.service';
import { ProfileService } from '../services/profile.service';
import { Profile } from '../models/profile';
 import { SnackbarService } from '../services/snackbar.service';

@Component({
  selector: 'app-addtocart',
  templateUrl: './addtocart.component.html',
  styleUrls: ['./addtocart.component.css']
})
export class AddtocartComponent  {

  @Input('productId') productId: number;

  profile: Profile ;
  userId;
  constructor(
    private cartService: CartService,
    private userService: ProfileService,
     private snackBarService: SnackbarService
  ) {


    this.userService.getProfile().subscribe(profile => {

      this.profile = profile;
    // console.log(`PROF: ${this.profile.id}`);
      this.userId = this.profile.id;
     // this.userService.cartItemcount$();
    }, error => console.log(error));

    this.cartService.getOldCart();
  }

  

  addToCart() {
    this.cartService.addProductToCart(this.userId, this.productId).subscribe(
      result => {
        this.userService.cartItemcount$.next(result);
        this.snackBarService.showSnackBar(`One Item added to cart`);
        console.log(`One Item added to cart`);
      }, error => {
        console.log(`Error ocurred while addToCart data :${error}`);
      });
  }  

}
