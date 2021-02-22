import IUser from '../IUser';

export interface IAuthenticate {
    token: string;
    user: IUser;
}
