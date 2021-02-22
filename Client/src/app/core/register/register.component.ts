import { AuthService } from './../auth.service';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  form: FormGroup;
  isLoading = false;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.form = this.fb.group({
      username: ['', [Validators.required]],
      firstname: ['', [Validators.required]],
      lastname: ['', [Validators.required]],
      email: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
   }

   submitHandler(): void {
    const data = this.form.value;
    this.isLoading = true;

    this.authService.register(data).subscribe({
      next: () => {
        this.isLoading = false;
        this.router.navigate(['login']);
      },
      error: (err) => {
        this.isLoading = false;
        console.error(err);
      }
    });
  }

}
