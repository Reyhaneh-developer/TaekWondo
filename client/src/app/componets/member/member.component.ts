import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { RouterLink } from '@angular/router';
import { Member } from '../../models/member.model';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { Observable } from 'rxjs';
import { MemberService } from '../../services/member.service';

@Component({
  selector: 'app-member',
  imports: [
    MatCardModule,
    MatIconModule
  ],
  templateUrl: './member.component.html',
  styleUrl: './member.component.scss'
})
export class MemberComponent {
  // accessorService = inject(AccountService);
  memberService = inject(MemberService);
  membrs: Member[] | undefined;

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    let allMember$: Observable<Member[]> = this.memberService.getAllMembers();

    allMember$.subscribe({
      next: (res) => {
        this.membrs = res;
      }
    })
  }
}