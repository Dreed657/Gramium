import { environment } from './../../environments/environment';
import { ILoginModel } from './../shared/Interfaces/Auth/ILoginModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRegisterModel } from '../shared/Interfaces/Auth/IRegisterModel';
import { Router } from '@angular/router';

const tokenKey = 'token';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  login(data: ILoginModel): Observable<any> {
    return this.http.post('/api/auth/login', data);
  }

  register(data: IRegisterModel): Observable<any> {
    return this.http.post('/api/auth/register', data);
  }

  logout(): void {
    localStorage.removeItem(tokenKey);
    this.router.navigate(['/login']);
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
