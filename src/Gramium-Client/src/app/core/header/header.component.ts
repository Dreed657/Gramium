import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';
import { faHome, faPaperPlane, faCompass, faHeart, faCircle, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';

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

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }

  logout(): void {
    this.authService.logout();
  }

}
