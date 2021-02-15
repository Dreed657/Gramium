import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IComment } from '../shared/Interfaces/IComment.';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<IComment[]> {
    return this.http.get<IComment[]>('/Comments');
  }

  getAllByPostId(postId: number): Observable<IComment[]> {
    return this.http.get<IComment[]>(`/Comments/${postId}`);
  }

  getById(id: number): Observable<IComment[]> {
    return this.http.get<IComment[]>(`/Comments/${id}`);
  }

  // TODO: ADD MODEL FOR UPDATE METHOD
  updateComment(id: number, data: { content: string }): Observable<any> {
    return this.http.put(`/Comments/${id}`, data);
  }

  deleteComment(id: number): Observable<any> {
    return this.http.delete(`/Comments/${id}`);
  }

  // TODO: ADD MODEL FOR CREATE METHOD
  create(data: { postId: number, content: string }): Observable<any> {
    return this.http.post('/Comments', data);
  }
}
