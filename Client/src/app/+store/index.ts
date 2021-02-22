import { ActionReducerMap } from '@ngrx/store';
import { IGlobalState, globalReducer } from './reducers';

export interface IRootState {
    readonly global: IGlobalState;
}

export const reducers: ActionReducerMap<IRootState> = {
    global: globalReducer
};
