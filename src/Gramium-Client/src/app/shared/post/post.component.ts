import { PostsService } from './../services/posts.service';
import { Component, Input, OnInit } from '@angular/core';
import { IPost } from '../Interfaces/IPost';
import { faPaperPlane, faHeartbeat, faCircle, faComment, faEllipsisV } from '@fortawesome/free-solid-svg-icons';

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
  menuIcon = faEllipsisV;


  @Input() post: IPost;

  constructor(private postsService: PostsService) { }

  ngOnInit(): void {
  }

  deleteHandler(): void {
    console.log(this.post.id);
    this.postsService.deletePost(this.post.id).subscribe();
  }
}
