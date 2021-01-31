import { SharedModule } from './../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';

import { HeaderComponent } from './header/header.component';
import { NavbarModule, WavesModule, ButtonsModule, IconsModule } from 'angular-bootstrap-md';
import { appInterceptorProvider } from './app.interceptor';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [HeaderComponent, LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot(),
    NavbarModule,
    WavesModule,
    ButtonsModule,
    IconsModule,
    SharedModule,
  ],
  providers: [
    appInterceptorProvider
  ],
  exports: [HeaderComponent]
})
export class CoreModule { }
