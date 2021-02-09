import { PostsService } from './../posts.service';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IPost } from 'src/app/shared/Interfaces/IPost';

@Component({
  selector: 'app-post-profile',
  templateUrl: './post-profile.component.html',
  styleUrls: ['./post-profile.component.scss']
})
export class PostProfileComponent implements OnInit {
  @Input() post!: IPost;

  showInfo = false;

  constructor(private router: Router, private postService: PostsService) { }

  ngOnInit(): void {
  }

  goToHandler(): void {
    this.router.navigate(['/post', this.post.id]);
  }

  showOverlayHandler(): void {
    this.showInfo = true;
  }

  hideOverlayHandler(): void {
    this.showInfo = false;
  }
}
