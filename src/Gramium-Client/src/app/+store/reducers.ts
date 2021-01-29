import { createReducer, on } from '@ngrx/store';
import { logout, authenticate } from './actions';
import { IUser } from '../shared/Interfaces/IUser';

export interface IAuthState {
    currentUser: IUser | null | undefined;
}

export const initialState: IAuthState = {
    currentUser: undefined,
};

const setCurrentUser = (
    state: IAuthState,
    action: ReturnType<typeof authenticate>
    ) => {
    return { ...state, currentUser: action.user };
};

export const authReducer = createReducer<IAuthState>(
    initialState,
    on(authenticate, setCurrentUser),
    on(logout, (state) => {
        return { ...state, currentUser: null }
    })
);
