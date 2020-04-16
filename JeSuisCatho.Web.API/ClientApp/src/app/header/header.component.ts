import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { ProfileService } from '../services/profile.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';


export interface Profile {
  Id: string;
  Email: string;
  Name: string;
  
}

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {
  
  profile: Profile[];
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private toastrService: ToastrService,
   private auth: AuthService,
   private prof: ProfileService,
 ) {  }

  ngOnInit(): void {
   
    this.prof.getProfile().subscribe(profile => {

      this.profile = profile;
    }, error => console.log(error));

  // this.auth.tryFunct();
  }

 

  signOut() {
    this.auth.logout()
    this.toastrService.info('Bye Bye', 'Successfuly Logged out')
    this.router.navigate(['/signin']);
   // this.profile = {};
  }

 

}
