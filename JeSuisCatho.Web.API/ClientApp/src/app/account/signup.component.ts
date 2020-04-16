import { Component} from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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
    private toastrService: ToastrService,
    private authService: AuthService) {

  }

  ngOnInit(): void {

  }

    submitRegister() { 
      this.authService.create(this.account)
      .subscribe(x => {
        this.toastrService.success('Thank you', 'Account Registered Succesfuly');
      });
    }
  
}
