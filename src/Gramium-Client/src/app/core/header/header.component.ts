import { Component, OnInit } from '@angular/core';
import { faHome, faPaperPlane, faCompass, faHeart, faCircle } from '@fortawesome/free-solid-svg-icons';

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

  constructor() { }

  ngOnInit(): void {
  }

}
