import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { PostComponent } from './post/post.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

const DIcontainer = [
  LoaderComponent,
  PostComponent
];


@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    FontAwesomeModule
  ],
  exports: [DIcontainer]
})
export class SharedModule { }
