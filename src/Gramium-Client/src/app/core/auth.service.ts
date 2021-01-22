import { environment } from './../../environments/environment';
import { ILoginModel } from './../shared/Interfaces/Auth/ILoginModel';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IRegisterModel } from '../shared/Interfaces/Auth/IRegisterModel';

const API_KEY = environment.ApiUrl;

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(data: ILoginModel): Observable<any> {
    return this.http.post(`${API_KEY}/api/auth/login`, data);
  }

  register(data: IRegisterModel): Observable<any> {
    return this.http.post(`${API_KEY}/api/auth/register`, data);
  }
}
