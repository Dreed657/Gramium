import { AuthService } from './../../core/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginFrom = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
  }

  onSubmit(): void {
    console.log(this.loginFrom.value);
    this.authService.login(this.loginFrom.value).subscribe(data => {
      this.authService.saveToken(data.token);
      this.router.navigate(['']);
    });
  }

}
