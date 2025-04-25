import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { AppUser } from '../models/app-user.moder';
import { Observable } from 'rxjs';
import { LoggedIn } from '../models/logged-in.model';
import { Login } from '../models/login.model';
import { Member } from '../models/member.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  hhtp = inject(HttpClient);
  private readonly _baseApiUrl: string = 'http://localhost:5000/api/';

  register(user: AppUser): Observable<LoggedIn> {
    return this.hhtp.post<LoggedIn>(this._baseApiUrl + 'account/register', user);
  }

  login(userInput: Login): Observable<LoggedIn> {
    return this.hhtp.post<LoggedIn>(this._baseApiUrl + 'account/login', userInput);
  }

  getAllMember(): Observable<Member[]> {
    return this.hhtp.get<Member[]>(this._baseApiUrl + 'account');
  }
}
