import { PostsService } from './../posts.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {

  constructor(private postService: PostsService) { }

  ngOnInit(): void {
  }

}
