import { Component, Input, OnInit } from '@angular/core';
import { IComment } from 'src/app/shared/Interfaces/IComment.';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  @Input() comment!: IComment;

  constructor() { }

  ngOnInit(): void {
  }

}
