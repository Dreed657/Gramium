import { createAction, props } from '@ngrx/store';
import { IUser } from '../shared/Interfaces/IUser';

const authNamespace = '[AUTH]';

export const authenticate = createAction(`${authNamespace} AUTHENTICATE`, props<{ user: IUser }>());
export const logout = createAction(`${authNamespace} LOGOUT`);
