import { PostsService } from './../post/posts.service';
import { AuthService } from './../core/auth.service';
import { Component, OnInit } from '@angular/core';
import { IProfileInfo } from '../shared/Interfaces/IUser';
import { IPost } from '../shared/Interfaces/IPost';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  profileInfo!: IProfileInfo;
  posts!: IPost[];

  isInfoLoading = false;
  isPostsLoading = false;

  constructor(private authService: AuthService, private postService: PostsService) { }

  ngOnInit(): void {
    this.isInfoLoading = true;

    this.authService.getUser().subscribe({
      next: (res) => {
        this.isInfoLoading = false;
        this.profileInfo = res;
      },
      error: (err) => {
        this.isInfoLoading = false;
        console.error(err);
      }
    });

    this.isPostsLoading = true;

    this.postService.getCurrentUserPosts().subscribe({
      next: (res) => {
        this.isPostsLoading = false;
        this.posts = res;
      },
      error: (err) => {
        this.isPostsLoading = false;
        console.error(err);
      }
    });
  }
}
