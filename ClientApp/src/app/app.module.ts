// import * as Raven from 'raven-js';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule, registerLocaleData } from '@angular/common';
import 'hammerjs';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { ToastrModule } from 'ngx-toastr';
// import { ToastyModule } from 'ng2-toasty';
import { MatNativeDateModule } from '@angular/material';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { trigger, animate, style, group, animateChild, query, stagger, transition } from '@angular/animations';

//Borrowed Components
// import { NgDatepickerModule } from './ng-datepicker/module/ng-datepicker.module';ss


//User Components - for specific User Content
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';

import { HomeComponent } from './home/home.component';
import { ChurchFormComponent } from './church-form/church-form.component';
import { ErrorComponent } from './error/error.component';


import { SignupComponent } from './account/signup.component';
import { SigninComponent } from './account/signin.component';

import { PaginationComponent } from './shared/pagination.component';




//services

import { ChurchService } from './services/church.service';
import { AuthService } from './services/auth.service';
import { TokenInterceptorService } from './interceptor/httpconfig.interceptor';


//Pipes

import { AppErrorHandler } from './app.error-handler';

import en from '@angular/common/locales/en';

registerLocaleData(en);

//Raven.config('...').install();

import { BBSRevampMaterialModule } from '../material.module';



@NgModule({
  declarations: [
    AppComponent, PaginationComponent,
    HeaderComponent, HomeComponent, ErrorComponent,
    SignupComponent, SigninComponent, ChurchFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, ToastrModule.forRoot(),
    BrowserAnimationsModule, MatNativeDateModule,
    CommonModule, FormsModule, BBSRevampMaterialModule,

    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'not-found-error', component: ErrorComponent },



      // { path: 'library', component: LibraryComponent },
      { path: 'church/new', component: ChurchFormComponent },
      // { path: 'library/:id', component: LibAssetFormComponent },


      { path: 'signup', component: SignupComponent },
      { path: 'signin', component: SigninComponent },



      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [ { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService,
      multi: true  }],
  bootstrap: [AppComponent]
})
export class AppModule { }


platformBrowserDynamic().bootstrapModule(AppModule);
