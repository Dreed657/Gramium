import { PostsService } from './../posts.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
  styleUrls: ['./post-create.component.scss']
})
export class PostCreateComponent {

  testTrue = true;

  form: FormGroup;
  isLoading = false;

  constructor(private fb: FormBuilder, private postService: PostsService, private router: Router) {
    this.form = this.fb.group({
      imageUrl: ['', [Validators.required]],
      content: ['', [Validators.required]]
    });
   }

   submitHandler(): void {
      const data = this.form.value;
      this.isLoading = true;

      this.postService.createPost(data).subscribe({
        next: (res) => {
          console.log(res);
          let postId = res;
          this.isLoading = false;

          this.router.navigate([`post/${postId}`]);
        },
        error: (err) => {
          this.isLoading = false;
          console.error(err);
        }
      });
   }

}
