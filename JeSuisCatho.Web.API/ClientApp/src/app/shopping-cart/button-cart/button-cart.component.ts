import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ProfileService } from '../../services/profile.service';
import { SubscriptionService } from '../../services/subscription.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Profile } from '../../models/profile';




@Component({
  selector: 'app-button-cart',
  templateUrl: './button-cart.component.html',
  styleUrls: ['./button-cart.component.css']
})

export class ButtonCart {
  cartItemCount: number;
  userId;
  userDataSubscription: any;
  userData = new Profile();
  profile: Profile;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastrService: ToastrService,
    private auth: AuthService,
    private prof: ProfileService,
    private subscriptionService: SubscriptionService

  ) {

    this.userDataSubscription = this.subscriptionService.userData.asObservable().subscribe(data => {
      this.userData = data;

   

      this.prof.getCartItemCount(this.userId).subscribe((data: number) => {
        this.cartItemCount = data;
      
      });

      this.prof.cartItemcount$.subscribe(data => {
        this.cartItemCount = data;
      });

    });



   }


}
