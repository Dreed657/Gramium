import IUser from './IUser';

export interface IPost {
    id: number;
    user: IUser;
    content: string;
    imageUrl: string;
    createdAt: Date;
    likes: number;
    comments: number;
    isLiked: boolean;
}
