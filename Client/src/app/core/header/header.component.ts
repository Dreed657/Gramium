import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  currentUser$ = this.authService.currentUser$;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {}

  logoutHandler(): void {
    this.authService.logout();
  }
}
