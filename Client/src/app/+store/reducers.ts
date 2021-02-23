import { createReducer, on } from '@ngrx/store';
import IUser from './../shared/Interfaces/IUser';
import { login, logout } from './actions';

export interface IGlobalState {
    token: string | null | undefined;
    currentUser: IUser | null | undefined;
}

export const initialState: IGlobalState = {
    token: undefined,
    currentUser: undefined
};

const setUser = (
    state: IGlobalState,
    action: ReturnType<typeof login>
) => {
    return {...state, token: action.token, currentUser: action.user };
};

export const globalReducer = createReducer<IGlobalState>(
    initialState,
    on(login, setUser),
    on(logout, (state) => {
        return { ...state, currentUser: null, token: null };
    })
);
