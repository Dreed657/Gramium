import { createAction, props } from '@ngrx/store';
import { IAuthenticate } from '../shared/Interfaces/AUTH/IAuthenticate';
import IUser from './../shared/Interfaces/IUser';

const globalNamespace = '[GLOBAL]';

export const login = createAction(`${globalNamespace} Login`, props<IAuthenticate>());
export const logout = createAction(`${globalNamespace} LogOut`);
