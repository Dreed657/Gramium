import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { HeaderComponent } from './header/header.component';
import { NavbarModule, WavesModule, ButtonsModule, IconsModule } from 'angular-bootstrap-md';
import { appInterceptorProvider } from './app.interceptor';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const DIcontainer = [HeaderComponent];

@NgModule({
  declarations: [DIcontainer, LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    RouterModule,
    MDBBootstrapModule.forRoot(),
    NavbarModule,
    WavesModule,
    ButtonsModule,
    IconsModule,
  ],
  providers: [
    appInterceptorProvider
  ],
  exports: [DIcontainer]
})
export class CoreModule { }
