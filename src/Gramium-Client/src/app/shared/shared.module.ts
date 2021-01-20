import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { PostComponent } from './post/post.component';

const DIcontainer = [
  LoaderComponent,
  PostComponent
];


@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule
  ],
  exports: [DIcontainer]
})
export class SharedModule { }
