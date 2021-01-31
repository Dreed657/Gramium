import { Component, OnInit } from '@angular/core';
import { IPost } from 'src/app/shared/Interfaces/IPost';

@Component({
  selector: 'app-post-listing',
  templateUrl: './post-listing.component.html',
  styleUrls: ['./post-listing.component.scss']
})
export class PostListingComponent implements OnInit {
  posts: IPost[];

  constructor() {
    this.posts = [];
  }

  ngOnInit(): void {
  }

}
