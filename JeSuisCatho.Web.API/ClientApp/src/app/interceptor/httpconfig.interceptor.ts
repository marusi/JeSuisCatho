import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { AuthService } from '../services/auth.service';
import { finalize } from 'rxjs/operators';
import { LoaderService } from '../services/loader.service';


@Injectable({
  providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {

  requestCount = 0;

  constructor(private auth: AuthService, public loaderService: LoaderService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.requestCount++;
    this.loaderService.show();
    
   
    const token = this.auth.getToken();

    let newHeaders = req.headers;
    if (token) {
      newHeaders = newHeaders.append('Authorization', `Bearer ${token}`);
      newHeaders = newHeaders.append('Content-Type', 'application/json');
      newHeaders = newHeaders.append('Accept', 'application/json');


    }

  
     
    const authReq = req.clone({ headers: newHeaders });
    return next.handle(authReq).pipe(
      finalize(() => {
        this.requestCount--;
        if (this.requestCount === 0) {
          this.loaderService.hide();
        }
      })
    );
   
  }
}


