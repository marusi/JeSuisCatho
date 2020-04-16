// import * as Raven from 'raven-js';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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
// import { trigger, animate, style, group, animateChild, query, stagger, transition } from '@angular/animations';

//Borrowed Components
// import { NgDatepickerModule } from './ng-datepicker/module/ng-datepicker.module';ss


//User Components - for specific User Content
import { AppComponent } from './app.component';

import { CarouselComponent } from './carousel/carousel.component';

import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ChurchFormComponent } from './church-form/church-form.component';
import { ErrorComponent } from './error/error.component';
import { InfoDeskFormComponent } from './info-desk-form/info-desk-form.component';
import { NewsComponent } from './news/news.component';
import { ArticleListComponent } from './article-list/article-list.component';
import { ApplicationsComponent } from './application/application.component';
import { InquireComponent } from './application/inquire.component';
import { VisitsComponent } from './application/visits.component';
import { SignupComponent } from './account/signup.component';
import { SigninComponent } from './account/signin.component';

import { PaginationComponent } from './shared/pagination.component';
import { LoaderComponent } from './shared/loader/loader.component';
import { HeaderComponent } from './header/header.component';



//services
import { TokenInterceptorService } from './interceptor/httpconfig.interceptor';
import { LoaderService } from './services/loader.service';
import { ChurchService } from './services/church.service';
import { AuthService } from './services/auth.service';
import { ArticleService } from './services/article.service';

import { ProfileService } from './services/profile.service';



//Pipes


import en from '@angular/common/locales/en';

registerLocaleData(en);

//Raven.config('...').install();

import { BBSRevampMaterialModule } from '../material.module';



@NgModule({
  declarations: [
    AppComponent, PaginationComponent,
    HeaderComponent, HomeComponent, AboutComponent, ErrorComponent,
    SignupComponent, SigninComponent, ChurchFormComponent, LoaderComponent,
    InfoDeskFormComponent, NewsComponent, ArticleListComponent,
    CarouselComponent, ApplicationsComponent, InquireComponent, VisitsComponent
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
      { path: 'newsandevents', component: NewsComponent },
      { path: 'newsandevents/new', component: InfoDeskFormComponent },
      { path: 'newsandevents/:id', component: InfoDeskFormComponent },
      { path: 'church/new', component: ChurchFormComponent },
      { path: 'visarequirements', component: ApplicationsComponent },
      // { path: 'library/:id', component: LibAssetFormComponent },


      { path: 'signup', component: SignupComponent },
      { path: 'signin', component: SigninComponent },



      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [ { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService,
    multi: true
  }, LoaderService, ChurchService,
    AuthService, ArticleService, ProfileService],
  bootstrap: [AppComponent]
})
export class AppModule { }


platformBrowserDynamic().bootstrapModule(AppModule);
