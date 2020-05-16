// import * as Raven from 'raven-js';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule, registerLocaleData } from '@angular/common';
import 'hammerjs';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

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
import { ProductsComponent } from './products-list/products.component';
import { ProductFormComponent } from './product-form/product-form.component';
import { ViewProductComponent } from './view-product/view-product';
import { PaginationComponent } from './shared/pagination.component';
import { LoaderComponent } from './shared/loader/loader.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AddtocartComponent } from './addtocart/addtocart.component';
import { ShoppingCartComponent } from './shopping-cart/shoppingcart.component';
import { ButtonCart } from './shopping-cart/button-cart/button-cart.component';
import { ProductOrdersComponent } from './user-orders/user-orders.component';
import { CheckOutComponent } from './checkout/checkout.component';


//services
import { TokenInterceptorService } from './interceptor/httpconfig.interceptor';
import { LoaderService } from './services/loader.service';
import { ChurchService } from './services/church.service';
import { AuthService } from './services/auth.service';
import { ArticleService } from './services/article.service';
import { CartService } from './services/cart.service';
import { MpesaService } from './services/mpesa.service';
import { ProductService } from './services/product.service';
import { ProfileService } from './services/profile.service';
import { FileService } from './services/file.service';
import { SnackbarService } from './services/snackbar.service';
import { SubscriptionService } from './services/subscription.service';
import { ProductOrdersService } from './services/product.order.service';
import { CheckOutService } from './services/checkout.service';



//Pipes


import en from '@angular/common/locales/en';

registerLocaleData(en);

//Raven.config('...').install();

import { BBSRevampMaterialModule } from '../material.module';
import { ErrorInterceptorService } from './interceptor/error-interceptor.service';



@NgModule({
  declarations: [
    AppComponent, PaginationComponent, ProductsComponent, ProductFormComponent,
    HeaderComponent, FooterComponent, HomeComponent, AboutComponent, ErrorComponent,
    SignupComponent, SigninComponent, ChurchFormComponent, LoaderComponent,
    InfoDeskFormComponent, NewsComponent, ArticleListComponent, ViewProductComponent,
    CarouselComponent, ApplicationsComponent, InquireComponent, VisitsComponent, AddtocartComponent,
    ShoppingCartComponent, ButtonCart, ProductOrdersComponent, CheckOutComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, ReactiveFormsModule,
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
      { path: 'product/new', component: ProductFormComponent },
      { path: 'product/:id', component: ViewProductComponent  },
      { path: 'products', component: ProductsComponent },
      { path: 'shopping-cart', component: ShoppingCartComponent },
      { path: 'myorders', component: ProductOrdersComponent},
      { path: 'checkout', component: CheckOutComponent},
      // { path: 'library/:id', component: LibAssetFormComponent },


      { path: 'signup', component: SignupComponent },
      { path: 'signin', component: SigninComponent },



      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true },
    LoaderService, ChurchService, CartService, ProductService, SnackbarService, MpesaService,
    AuthService, ArticleService, ProfileService, FileService, SubscriptionService,
    ProductOrdersService, CheckOutService],
  bootstrap: [AppComponent]
})
export class AppModule { }


platformBrowserDynamic().bootstrapModule(AppModule);
