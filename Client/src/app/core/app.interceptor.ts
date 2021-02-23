import { Injectable, Provider } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { first, mergeMap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Store } from '@ngrx/store';
import { IRootState } from './../+store/index';

const apiURL = environment.ApiUrl;

@Injectable()
export class AppInterceptor implements HttpInterceptor {

  constructor(private store: Store<IRootState>) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (!req.url.includes('http')) {
      req = req.clone({
        url: `${apiURL}${req.url}`,
      });
    } else {
      return next.handle(req);
    }

    return this.store.select(state => state.global.token).pipe(
      first(),
      mergeMap(token => {
        const authReq = !!token ? req.clone({
          setHeaders: { Authorization: `Bearer ${token}`}
        }) : req;

        return next.handle(authReq);
      }),
    );
  }
}

export const appInterceptorProvider: Provider = {
  provide: HTTP_INTERCEPTORS,
  useClass: AppInterceptor,
  multi: true
};
