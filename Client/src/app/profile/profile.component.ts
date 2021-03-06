import { FollowService } from './../core/services/follow.service';
import { AuthService } from './../core/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { IProfileInfo } from '../shared/Interfaces/IProfileInfo';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  profileInfo!: IProfileInfo;

  isInfoLoading = false;

  constructor(
    private authService: AuthService,
    private followService: FollowService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    const username = this.route.snapshot.params.username;
    this.isInfoLoading = true;

    this.authService.getUser(username).subscribe({
      next: (res) => {
        this.isInfoLoading = false;
        this.profileInfo = res;

        if (this.profileInfo.profileImageUrl == null) {
          this.profileInfo.profileImageUrl = '/assets/default-profile.jpg';
        }
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

  FollowHandler(): void {
    this.followService.follow(this.profileInfo.id).subscribe({
      next: () => {
        this.profileInfo.isFollowing = !this.profileInfo.isFollowing;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  unFollowHandler(): void {
    this.followService.unFollow(this.profileInfo.id).subscribe({
      next: () => {
        this.profileInfo.isFollowing = !this.profileInfo.isFollowing;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }
}
