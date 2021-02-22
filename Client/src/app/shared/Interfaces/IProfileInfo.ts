import { IPost } from './IPost';

export interface IProfileInfo {
    firstName: string;
    lastName: string;
    userName: string;
    profileImageUrl: string;
    postsCount: number;
    posts: IPost[];
    followers: number;
    following: number;
}
