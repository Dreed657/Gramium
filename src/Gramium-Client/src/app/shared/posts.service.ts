import { Injectable } from '@angular/core';
import { IPost } from './Interfaces/IPost';

@Injectable({
  providedIn: 'root'
})
export class PostsService {

  constructor() { }

  getAllPosts(): IPost[] {
    return [
      {
        Content: 'https://picsum.photos/200/300?random=1',
        CreatedOn: '00:00:2020 00:00',
        UserName: 'Pesho1'
      },
      {
        Content: 'https://picsum.photos/200/300?random=2',
        CreatedOn: '00:10:2020 23:00',
        UserName: 'Pesho2'
      },
      {
        Content: 'https://picsum.photos/200/300?random=3',
        CreatedOn: '24:05:2020 02:00',
        UserName: 'Pesho3'
      },
    ];
  }
}
