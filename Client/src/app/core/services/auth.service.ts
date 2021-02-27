import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ILogin, IRegister } from '../../shared/Interfaces/AUTH';
import { IProfileInfo } from '../../shared/Interfaces/IProfileInfo';
import { login, logout } from './../../+store/actions';
import { Store } from '@ngrx/store';
import { IAuthenticate } from '../../shared/Interfaces/AUTH/IAuthenticate';
import { tap, map } from 'rxjs/operators';
import { IRootState } from '../../+store/index';

const tokenKey = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser$ = this.store.select((state) => state.global.currentUser);

  constructor(private http: HttpClient, private router: Router, private store: Store<IRootState>) {}

  getUser(username: string): Observable<IProfileInfo> {
    return this.http.get<IProfileInfo>(`/profiles?username=${username}`);
  }

  login(data: ILogin): Observable<IAuthenticate> {
    return this.http.post<IAuthenticate>('/identity/login', data).pipe(
      tap((res: IAuthenticate) => {
        this.store.dispatch(login(res));
      })
    );
  }

  register(data: IRegister): Observable<any> {
    return this.http.post('/identity/register', data);
  }

  logout(): void {
    this.store.dispatch(logout());
    this.router.navigate(['login']);
  }

  // ##Deprecated
  // saveToken(token: string): void {
  //   localStorage.setItem(tokenKey, token);
  // }

  // getToken(): string | null {
  //   return localStorage.getItem(tokenKey);
  // }

  // isAuthenticated(): boolean {
  //   if (this.getToken()) {
  //     return true;
  //   }
  //   return false;
  // }
}
