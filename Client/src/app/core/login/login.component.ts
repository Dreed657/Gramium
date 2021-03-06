import { AuthService } from './../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  form: FormGroup;
  isLoading = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router, private toastr: ToastrService) {
    this.form = this.fb.group({
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
   }

  submitHandler(): void {
    const data = this.form.value;
    this.isLoading = true;

    this.authService.login(data).subscribe({
      next: (res) => {
        this.router.navigate(['/']);
        this.toastr.success(`Hello ${res.user.username}`, 'Login!');
      },
      error: (err) => {
        this.isLoading = false;
        console.error(err);
      }
    });
  }
}
