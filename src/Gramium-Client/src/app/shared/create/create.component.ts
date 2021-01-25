import { PostsService } from './../services/posts.service';
import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {
  form = new FormGroup({
    Content: new FormControl('', [Validators.required]),
    ImageUrl: new FormControl('', [Validators.required]),
  });

  @Output() newPost = new EventEmitter();

  constructor(private postsService: PostsService) { }

  sumbitHandler(): void {
    this.postsService.createPost(this.form.value).subscribe(x => {
      this.newPost.emit(x);
    });
  }

}
