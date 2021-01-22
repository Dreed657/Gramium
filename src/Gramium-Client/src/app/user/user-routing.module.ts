import { AuthGuard } from './../core/guards/auth.guard';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  {
    path: 'login',
    pathMatch: 'full',
    component: LoginComponent,
  },
  {
    path: 'register',
    pathMatch: 'full',
    component: RegisterComponent,
  },
  {
    path: 'user',
    canActivate: [AuthGuard],
    children: [],
  }
];

export const UserRoutingModule = RouterModule.forChild(routes);
