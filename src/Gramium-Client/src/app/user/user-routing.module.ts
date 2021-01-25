import { ProfileComponent } from './profile/profile.component';
import { AuthGuard } from './../core/guards/auth.guard';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent,
    data: [
      {
        hideNavigation: true,
      }
    ]
  },
  {
    path: 'register',
    pathMatch: 'full',
    component: RegisterComponent,
    data: [
      {
        hideNavigation: false,
      }
    ]
  },
  {
    path: 'user',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'profile',
        pathMatch: 'full',
        component: ProfileComponent,
      }
    ],
  }
];

export const UserRoutingModule = RouterModule.forChild(routes);
