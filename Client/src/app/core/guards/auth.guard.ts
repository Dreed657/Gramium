import { AuthService } from './../auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { switchMap, tap, map, first } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {


  constructor(private authService: AuthService, private router: Router) { }

  canActivate(): boolean {
    return true;
  }

  // canActivate(): Observable<boolean> {
  //   return this.authService.currentUser$.pipe(
  //     map((user) => {
  //       return !!user;
  //     }),
  //     tap((canContinue) => {
  //       if (canContinue) { return; }
  //       const url = this.router.url;
  //       this.router.navigateByUrl(url);
  //     }),
  //     first()
  //   );
  // }
}
