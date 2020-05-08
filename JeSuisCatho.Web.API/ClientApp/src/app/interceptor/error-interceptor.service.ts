import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorInterceptorService {

  constructor(
    private authService: AuthService,
    private router: Router,
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      if (err.status === 401) {
        this.authService.logout();
        if (!request.url.includes('signin')) {
         // location.reload();

          console.log(`Reload`);
        }
      } else if (err.status === 404) {
        this.router.navigate(['not-found-error']);
      }
      const error = err.error.message || err.statusText;
      return throwError(error);
    }));
  }
}
