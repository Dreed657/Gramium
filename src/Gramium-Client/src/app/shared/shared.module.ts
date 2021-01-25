import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { PostComponent } from './post/post.component';
import { HttpClientModule } from '@angular/common/http';
import { TimeDiffPipe } from './pipes/time-diff.pipe';

const DIcontainer = [
  LoaderComponent,
  PostComponent,
  TimeDiffPipe,
];


@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    HttpClientModule,
    FontAwesomeModule
  ],
  exports: [DIcontainer]
})
export class SharedModule { }
