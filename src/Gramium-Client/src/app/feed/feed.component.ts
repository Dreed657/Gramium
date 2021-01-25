import { Component, OnInit } from '@angular/core';
import { IPost } from '../shared/Interfaces/IPost';
import { PostsService } from '../shared/services/posts.service';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.scss']
})
export class FeedComponent implements OnInit {
  posts: IPost[];
  isLoading = true;

  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
    this.postsService.getFeed().subscribe(data => {
      console.log(data);
      this.posts = data;
    });
  }

}
