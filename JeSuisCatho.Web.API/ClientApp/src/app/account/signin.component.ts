import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { SubscriptionService } from '../services/subscription.service'

import { Router, ActivatedRoute } from '@angular/router';
import { ProfileService } from '../services/profile.service';
import { ToastrService } from 'ngx-toastr';
import { Profile } from '../models/profile';


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})

export class SigninComponent {
  oldUserId;
  profile: Profile;
  private account = {
    email: '',
    password: ''
  }



  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastrService: ToastrService,
    private profService: ProfileService,
    private subscriptionService: SubscriptionService,
    private authService: AuthService) {

  }

     

  submitCredentials() {
    this.authService.login(this.account).subscribe(res => {


      for (const [key, value] of Object.entries(res)) {
       
        if (key === "message") {
          localStorage.setItem('token', value);
    
         
        }
      }
    
        this.toastrService.success('Welcome', 'Karibu, Bienvenue')
        this.router.navigate(['/']);
      });
 
  }



   

}
