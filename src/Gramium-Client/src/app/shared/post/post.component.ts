import { Component, Input, OnInit } from '@angular/core';
import { IPost } from '../Interfaces/IPost';
import { faPaperPlane, faHeartbeat, faCircle, faComment } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.scss']
})
export class PostComponent implements OnInit {

  likeIcon = faHeartbeat;
  commentIcon = faComment;
  sendIcon = faPaperPlane;
  profileIcon = faCircle;

  @Input() post: IPost;

  constructor() { }

  ngOnInit(): void {
  }

}
