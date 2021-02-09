import { Component, Input, OnInit } from '@angular/core';
import { IPost } from 'src/app/shared/Interfaces/IPost';

@Component({
  selector: 'app-post-profile',
  templateUrl: './post-profile.component.html',
  styleUrls: ['./post-profile.component.scss']
})
export class PostProfileComponent implements OnInit {
  @Input() post!: IPost;

  showInfo = false;

  constructor() { }

  ngOnInit(): void {
  }

  showOverlayHandler(): void {
    this.showInfo = true;
  }
  
  hideOverlayHandler(): void {
    this.showInfo = false;
  }
}
