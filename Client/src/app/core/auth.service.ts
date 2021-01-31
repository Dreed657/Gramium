import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { ILogin, IRegister } from '../shared/Interfaces/AUTH';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router) { }

  login(data: ILogin): Observable<any> {
    return this.http.post('/identity/login', data);
  }

  register(data: IRegister): Observable<any> {
    return this.http.post('/identity/register', data);
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['login']);
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
      if (this.getToken()) {
        return true;
      }
      return false;
  }
}
