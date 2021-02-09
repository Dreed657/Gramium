import { TimeDiffPipe } from './pipes/time-diff.pipe';
import { CoreModule } from './../core/core.module';
import { NgModule } from '@angular/core';

import { ButtonsModule, WavesModule, CardsModule } from 'angular-bootstrap-md';
import { CommonModule } from '@angular/common';
import { SharedModule } from './../shared/shared.module';

import { PostComponent } from './post/post.component';
import { PostListingComponent } from './post-listing/post-listing.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { PostProfileComponent } from './post-profile/post-profile.component';
import { RouterModule } from '@angular/router';

const DIcontainer = [PostComponent, PostListingComponent, PostDetailComponent, PostProfileComponent, TimeDiffPipe];

@NgModule({
  declarations: [DIcontainer],
  imports: [
    CoreModule,
    RouterModule,
    CommonModule,
    SharedModule,
    CardsModule,
    WavesModule,
    ButtonsModule
  ],
  exports: [DIcontainer],
})
export class PostModule { }
