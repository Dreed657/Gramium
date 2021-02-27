import { Component, OnInit } from '@angular/core';
import { PostsService } from '../post/posts.service';
import { IPost } from '../shared/Interfaces/IPost';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit {

  postsCount = 0;
  pageNumber = 1;
  pageSize = 5;

  posts: IPost[] | undefined;

  constructor(private postService: PostsService) { }

  ngOnInit(): void {
    this.getPosts();
  }

  onScroll(): void {
    console.log('scrolled!!');
  }

  getPosts(): void {
    this.postService.getAll().subscribe({
      next: (res) => {
        this.posts = res;
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

}
