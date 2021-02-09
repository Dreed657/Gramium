import { NgModule } from '@angular/core';

import { ButtonsModule, WavesModule, CardsModule } from 'angular-bootstrap-md';
import { CommonModule } from '@angular/common';
import { SharedModule } from './../shared/shared.module';

import { PostComponent } from './post/post.component';
import { PostListingComponent } from './post-listing/post-listing.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { PostProfileComponent } from './post-profile/post-profile.component';

const DIcontainer = [PostComponent, PostListingComponent, PostDetailComponent, PostProfileComponent];

@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    SharedModule,
    CardsModule,
    WavesModule,
    ButtonsModule
  ],
  exports: [DIcontainer],
})
export class PostModule { }
