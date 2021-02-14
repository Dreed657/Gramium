import { PostsService } from './../post/posts.service';
import { AuthService } from './../core/auth.service';
import { Component, OnInit } from '@angular/core';
import { IProfileInfo } from '../shared/Interfaces/IUser';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  profileInfo!: IProfileInfo;

  isInfoLoading = false;

  constructor(private authService: AuthService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    const username = this.route.snapshot.params.username;
    this.isInfoLoading = true;

    this.authService.getUser(username).subscribe({
      next: (res) => {
        this.isInfoLoading = false;
        this.profileInfo = res;
      },
      error: (err) => {
        this.isInfoLoading = false;

        // TODO: REFACTOR THIS REDIRECT
        if (err.status === 404) {
          this.router.navigate([`pagenotfound`]);
        }
      }
    });
  }
}
