export interface IPost {
    id: number;
    userName: string;
    content: string;
    imageUrl: string;
    createdAt: Date;
    likes: number;
    comments: number;
    isLiked: boolean;
}
