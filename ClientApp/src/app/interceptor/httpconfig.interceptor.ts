import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import {AuthService} from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService  implements HttpInterceptor {

  constructor(private auth: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
   // console.log('INTERCEPTOR');
    const token = this.auth.getToken();
    let newHeaders = req.headers;
    if (token) {
      newHeaders = newHeaders.append('Authorization', `Bearer ${token}`);
      newHeaders = newHeaders.append('Content-Type', 'application/json');
      newHeaders = newHeaders.append('Accept', 'application/json');
     

    }
    const authReq = req.clone({ headers: newHeaders });
    return next.handle(authReq);
  }
}
