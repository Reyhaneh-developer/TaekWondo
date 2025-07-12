import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../models/member.model';

@Injectable({
  providedIn: 'root'
})
export class MemberService {
  http = inject(HttpClient);
  private readonly _baseApiUrl: string = 'http://localhost:5000/api/';

  getAllMembers(): Observable<Member[]> {
      let members$: Observable<Member[]>
        = this.http.get<Member[]>(this._baseApiUrl + 'member/get-all');
  
      return members$;
    }
}
