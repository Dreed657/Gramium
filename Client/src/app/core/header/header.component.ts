import { ToastrService } from 'ngx-toastr';
import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  currentUser$ = this.authService.currentUser$;

  constructor(private authService: AuthService, private toastr: ToastrService) { }

  ngOnInit(): void {}

  logoutHandler(): void {
    this.authService.logout();
    this.toastr.success('Good bye!', 'Logout success');
  }
}
