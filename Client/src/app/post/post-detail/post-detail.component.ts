import { PostsService } from './../posts.service';
import { Component, OnInit } from '@angular/core';
import { IPost } from 'src/app/shared/Interfaces/IPost';
import { ActivatedRoute } from '@angular/router';
import { IDetailPost } from 'src/app/shared/Interfaces/IDetailPost';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {

  post!: IDetailPost;

  isPostLoading = false;

  constructor(private route: ActivatedRoute, private postService: PostsService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.params.postId;
    this.isPostLoading = true;

    this.postService.getPost(id).subscribe({
      next: (res) => {
        this.post = res;
        this.isPostLoading = false;
      },
      error: (err) => {
        this.isPostLoading = false;
        console.error(err);
      }
    });
  }

  like(): void {
    this.postService.like(this.post.id).subscribe({
      error: (err) => {
        return console.error(err);
      }
    });

    this.post.isLiked = !this.post.isLiked;
    this.post.likes++;
  }

  unLike(): void {
    this.postService.unLike(this.post.id).subscribe({
      error: (err) => {
        console.error(err);
      }
    });
    this.post.isLiked = !this.post.isLiked;
    this.post.likes--;
  }

}
