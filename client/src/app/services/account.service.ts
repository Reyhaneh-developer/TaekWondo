// import { HttpClient } from '@angular/common/http';
import { inject, Injectable, PLATFORM_ID, signal } from '@angular/core';
import { AppUser } from '../models/app-user.moder';
import { map, Observable } from 'rxjs';
import { LoggedIn } from '../models/logged-in.model';
import { Login } from '../models/login.model';
import { Member } from '../models/member.model';
import { isPlatformBrowser } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  http = inject(HttpClient);
  platformId = inject(PLATFORM_ID);
  router = inject(Router);
  private readonly _baseApiUrl: string = 'http://localhost:5000/api/';
  loggedInUserSig = signal<LoggedIn | null>(null);

  register(userInput: AppUser): Observable<LoggedIn | null> {
    return this.http.post<LoggedIn>(this._baseApiUrl + 'account/register', userInput).pipe(
      map(res => {
        if (res) {
          this.setCurrentUser(res);

          return res;
        }

        return null;
      })
    );
  }

  login(userInput: Login): Observable<LoggedIn> {
    return this.http.post<LoggedIn>(this._baseApiUrl + 'account/login', userInput).pipe(
      map(userResponse => {
        this.setCurrentUser(userResponse);

        return userResponse;
      })
    )
  }

  setCurrentUser(loggedInUser: LoggedIn): void {
    this.loggedInUserSig.set(loggedInUser);
    console.log(this.loggedInUserSig);

    if (isPlatformBrowser(this.platformId)) {
      localStorage.setItem('loggedInUser', JSON.stringify(loggedInUser));
    }
  }

  logout(): void {
    this.loggedInUserSig.set(null);

    if (isPlatformBrowser(this.platformId)) {
      localStorage.clear();
    }

    this.router.navigateByUrl('account/login');
  }
}