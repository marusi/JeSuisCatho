import { Component} from '@angular/core';
import { AuthService } from '../services/auth.service';

import { Router, ActivatedRoute } from '@angular/router';
import { SnackbarService } from '../services/snackbar.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent  {

  private account = {

    firstName: '',
    lastName: '',
    phoneNumber: '',
    password: '',
    confirmPassword: '',
    email: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private snackBarService: SnackbarService,
    private authService: AuthService) {

  }

  ngOnInit(): void {

  }

    submitRegister() { 
      this.authService.create(this.account)
      .subscribe(x => {
        this.snackBarService.showSnackBar('Account is successfuly registered');
      });
    }
  
}
