import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FollowService {

  constructor(private http: HttpClient) { }

  follow(userId: string): Observable<any> {
    return this.http.post('/follows', { userId });
  }

  unFollow(userId: string): Observable<any> {
    return this.http.put('/follows', { userId });
  }
}
