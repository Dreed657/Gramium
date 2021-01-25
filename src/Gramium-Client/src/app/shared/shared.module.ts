import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { PostComponent } from './post/post.component';
import { HttpClientModule } from '@angular/common/http';
import { TimeDiffPipe } from './pipes/time-diff.pipe';
import { CreateComponent } from './create/create.component';
import { ReactiveFormsModule } from '@angular/forms';

const DIcontainer = [
  LoaderComponent,
  PostComponent,
  TimeDiffPipe,
  CreateComponent
];

@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HttpClientModule,
    FontAwesomeModule,
  ],
  exports: [DIcontainer]
})
export class SharedModule { }
