import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../shared/Interfaces/IPost';
import { ICreatePost } from '../shared/Interfaces/ICreatePost';
import { IDetailPost } from '../shared/Interfaces/IDetailPost';

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

  getPost(id: number): Observable<IDetailPost> {
    return this.http.get<IDetailPost>(`/posts/${id}`);
  }

  createPost(data: ICreatePost): Observable<{ id: number }> {
    return this.http.post<{ id: number }>('/posts', data);
  }

  like(postId: number): Observable<any> {
    return this.http.post('/likes', { postId });
  }

  unLike(postId: number): Observable<any> {
    return this.http.put('/likes', { postId });
  }

  updatePost(id: number, data: {content: string}): void {
    this.http.put(`/posts/${id}`, data);
  }

  deletePost(id: number): void {
    this.http.delete(`/posts/${id}`);
  }
}
