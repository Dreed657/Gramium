import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  form: FormGroup;
  isLoading = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
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
        this.isLoading = false;
        this.authService.saveToken(res.token);
        this.router.navigate(['']);
      },
      error: (err) => {
        this.isLoading = false;
        console.error(err);
      }
    });
  }
}
