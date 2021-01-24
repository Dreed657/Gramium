import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { PostComponent } from './post/post.component';
import { HttpClientModule } from '@angular/common/http';

const DIcontainer = [
  LoaderComponent,
  PostComponent
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
