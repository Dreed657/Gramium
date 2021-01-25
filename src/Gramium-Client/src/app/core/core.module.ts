import { RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthService } from './auth.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HttpClientModule } from '@angular/common/http';
import { appInterceptorProvider } from './app.interceptor';

const DIcontainer = [
  HeaderComponent,
  FooterComponent
];

@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    FontAwesomeModule,
    HttpClientModule,
    RouterModule,
  ],
  providers: [
    AuthService,
    AuthGuard,
    appInterceptorProvider
  ],
  exports: [DIcontainer]
})
export class CoreModule { }
