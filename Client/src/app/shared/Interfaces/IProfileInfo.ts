import { IPost } from './IPost';

export interface IProfileInfo {
    id: string;
    firstName: string;
    lastName: string;
    userName: string;
    profileImageUrl: string;
    postsCount: number;
    posts: IPost[];
    followers: number;
    following: number;
    isFollowing: boolean | null;
}
