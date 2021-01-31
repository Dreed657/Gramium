import { IPost } from './IPost';

export interface IUser {
    firstName: string;
    lastName: string;
    userName: string;
    posts: IPost;
}
