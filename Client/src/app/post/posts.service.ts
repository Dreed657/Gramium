import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../shared/Interfaces/IPost';
import { ICreatePost } from '../shared/Interfaces/ICreatePost';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor(private http: HttpClient) { }

  getCurrentUserPosts(): Observable<IPost[]> {
    return this.http.get<IPost[]>('/posts/mine');
  }

  getAll(): Observable<IPost[]> {
    return this.http.get<IPost[]>('/posts');
  }

  getPost(id: number): Observable<IPost> {
    return this.http.get<IPost>(`/posts/${id}`);
  }

  createPost(data: ICreatePost): void {
    this.http.post('/posts', data);
  }

  updatePost(id: number, data: {content: string}): void {
    this.http.put(`/posts/${id}`, data);
  }

  deletePost(id: number): void {
    this.http.delete(`/posts/${id}`);
  }
}
