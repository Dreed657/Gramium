import { AuthService } from './../core/auth.service';
import { Component, OnInit } from '@angular/core';
import { IUser } from '../shared/Interfaces/IUser';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  user!: IUser;

  isLoading = false;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    this.isLoading = true;

    this.authService.getUser().subscribe({
      next: (res) => {
        this.isLoading = false;
        this.user = res;
        console.log(res);
      },
      error: (err) => {
        this.isLoading = false;
        console.error(err);
      }
    });
  }
}
