import { ILoginModel } from './../shared/Interfaces/Auth/ILoginModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRegisterModel } from '../shared/Interfaces/Auth/IRegisterModel';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { IUser } from '../shared/Interfaces/IUser';
import { authenticate, logout } from '../+store/actions';
import { IRootState } from '../+store';

const tokenKey = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser$ = this.store.select((state) => state.auth.currentUser);

  constructor(private http: HttpClient, private router: Router, private store: Store<IRootState>) { }

  login(data: ILoginModel): Observable<any> {
    return this.http.post('/api/auth/login', data);
  }

  register(data: IRegisterModel): Observable<any> {
    return this.http.post('/api/auth/register', data);
  }

  logout(): void {
    localStorage.removeItem(tokenKey);
    this.store.dispatch(logout());
    this.router.navigate(['/login']);
  }

  setCurrentUser(): void {
    this.http.get('/api/users/GetCurrentUser').pipe(
      tap((user: IUser) => this.store.dispatch(authenticate( { user } )))
    );
  }

  saveToken(token): void {
    localStorage.setItem(tokenKey, token);
  }

  getToken(): string {
    return localStorage.getItem(tokenKey);
  }

  isAuthenticated(): boolean {
      if (this.getToken()) {
        return true;
      }
      return false;
  }
}
