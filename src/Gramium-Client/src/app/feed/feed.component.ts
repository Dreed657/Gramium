import { Component, OnInit } from '@angular/core';
import { IPost } from '../shared/Interfaces/IPost';
import { PostsService } from '../shared/posts.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit {
  posts: IPost[];

  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
    this.posts = this.postsService.getAllPosts();
  }

}
