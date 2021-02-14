import { PostCreateComponent } from './post/post-create/post-create.component';
import { PostDetailComponent } from './post/post-detail/post-detail.component';
import { AuthGuard } from './core/guards/auth.guard';
import { RegisterComponent } from './core/register/register.component';
import { LoginComponent } from './core/login/login.component';
import { ProfileComponent } from './profile/profile.component';
import { FeedComponent } from './feed/feed.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    component: FeedComponent,
  },
  {
    path: 'profile/:username',
    canActivate: [AuthGuard],
    component: ProfileComponent,
  },
  {
    path: 'post/:postId',
    component: PostDetailComponent
  },
  {
    path: 'create',
    component: PostCreateComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: '**',
    component: NotFoundComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
