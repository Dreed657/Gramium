import { PostsService } from './../posts.service';
import { Component, OnInit } from '@angular/core';
import { IPost } from 'src/app/shared/Interfaces/IPost';
import { ActivatedRoute, Router } from '@angular/router';
import { IDetailPost } from 'src/app/shared/Interfaces/IDetailPost';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommentService } from './../../comment/comment.service';

@Component({
  selector: 'app-post-detail',
  templateUrl: './post-detail.component.html',
  styleUrls: ['./post-detail.component.scss']
})
export class PostDetailComponent implements OnInit {

  commentForm: FormGroup;

  post!: IDetailPost;

  isPostLoading = false;
  isCommentSending = false;

  constructor(
    private route: ActivatedRoute,
    private postService: PostsService,
    private commentService: CommentService,
    private router: Router,
    private fb: FormBuilder) {
      this.commentForm = this.fb.group({
        content: ['', [Validators.required]]
      });
   }

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

        // TODO: REFACTOR THIS REDIRECT
        if (err.status === 404) {
          this.router.navigate([`pagenotfound`]);
        }
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

  commentSubmitHandler(): void {
    const data = this.commentForm.value;
    this.isCommentSending = true;

    data.postId = this.post.id;

    this.commentService.create(data).subscribe({
      next: (res) => {
        this.isCommentSending = false;
        this.commentForm.reset();

        this.post.comments.push(res);
        this.post.commentsCount++;
      },
      error: (err) => {
        // TODO: ADD TOASTER ERROR

        this.isCommentSending = false;
        console.error(err);
      }
    });
  }
}
