import { Component } from '@angular/core';
import { transition, trigger, query, style, animate } from '@angular/animations';
import { AuthService } from './services/auth.service';





@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  animations: [
    trigger( 'myAnimation', [
    transition('* => *', [
      query(
        ':enter',
        [style({ opacity: 0 })],
        { optional: true }
        
      ),
      query(
          ':leave',
          [style({ opacity: 1 }), animate('0.3s', style({ opacity: 0 }))],
          { optional: true }
      ),
      query(
        ':enter',
         [style({ opacity: 0 }), animate('0.3s', style({ opacity: 1 }))],
        { optional: true }
      )
    ])
   ]),

  ] // register the animations

})
export class AppComponent {



  constructor(private authService: AuthService) {
   // this.authService.setUserDetails();
  }
  title = 'app';
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

 

  
}
