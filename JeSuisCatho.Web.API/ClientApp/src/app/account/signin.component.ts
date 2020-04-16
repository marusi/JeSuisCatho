import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.css']
})

export class SigninComponent implements OnInit {

  private account = {
    email: '',
    password: ''
  }



  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastrService: ToastrService,
    private authService: AuthService) {

  }

      ngOnInit() : void {



       }

  submitCredentials() {
    this.authService.login(this.account).subscribe(res => {


      for (let [key, value] of Object.entries(res)) {
       
        if (key === "message") {
          localStorage.setItem('token', value)
        }
      }
    
        this.toastrService.success('Welcome', 'Karibu, Bienvenue')
        this.router.navigate(['/']);
      });
 
  }



   

}
