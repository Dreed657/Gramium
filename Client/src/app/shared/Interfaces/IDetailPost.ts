import { IComment } from './IComment.';

export interface IDetailPost {
    id: number;
    userId: string;
    userName: string;
    imageUrl: string;
    content: string;
    createdOn: Date;
    commentsCount: number;
    comments: IComment;
    likes: number;
    isLiked: boolean;
}
