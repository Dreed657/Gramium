import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentComponent } from './comment/comment.component';
import { SharedModule } from '../shared/shared.module';
import { RouterModule } from '@angular/router';

const DIContainer = [CommentComponent];

@NgModule({
  declarations: [DIContainer],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ],
  exports: [DIContainer]
})
export class CommentModule { }
