import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../Interfaces/IPost';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private http: HttpClient) { }

  getFeed(): Observable<IPost[]> {
    return this.http.get<IPost[]>('/api/posts/getall');
  }

  createPost(data): Observable<IPost>  {
    return this.http.post<IPost>('/api/posts', data);
  }
}
