import { ActionReducerMap } from '@ngrx/store';
import { IAuthState, authReducer } from './reducers';

export interface IRootState {
    readonly auth: IAuthState;
}

export const reducers: ActionReducerMap<IRootState> = {
    auth: authReducer,
};
