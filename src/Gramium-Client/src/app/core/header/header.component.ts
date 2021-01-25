import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { faHome, faPaperPlane, faCompass, faHeart, faCircle, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import { ActivationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  homeIcon = faHome;
  messagesIcon = faPaperPlane;
  discoverIcon = faCompass;
  likesIcon = faHeart;
  profileIcon = faCircle;
  logoutIcon = faSignOutAlt;

  hideNavigation = true;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    // this.router.events.pipe(
    //   filter(e => e instanceof ActivationEnd),
    //   map((e: ActivationEnd) => e.snapshot.data)
    // ).subscribe(data => {
    //   this.hideNavigation = data === undefined ? true : data.hideNavigation;
    // });
  }

  logout(): void {
    this.authService.logout();
  }

}
