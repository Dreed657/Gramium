import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthService } from './auth.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

const DIcontainer = [
  HeaderComponent,
  FooterComponent
];

@NgModule({
  declarations: [DIcontainer],
  imports: [
    CommonModule,
    FontAwesomeModule
  ],
  providers: [
    AuthService
  ],
  exports: [DIcontainer]
})
export class CoreModule { }
