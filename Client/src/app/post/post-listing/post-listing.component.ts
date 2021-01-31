import { Component, Input, OnInit } from '@angular/core';
import { IPost } from 'src/app/shared/Interfaces/IPost';
import { PostsService } from '../posts.service';

@Component({
  selector: 'app-post-listing',
  templateUrl: './post-listing.component.html',
  styleUrls: ['./post-listing.component.scss']
})
export class PostListingComponent implements OnInit {
  posts: IPost[] | undefined;

  constructor(private postService: PostsService) { }

  ngOnInit(): void {
    this.postService.getAll().subscribe({
      next: (res) => {
        this.posts = res;
        console.log(res);
      },
      error: (err) => {
        console.error(err);
      }
    });
  }

}
