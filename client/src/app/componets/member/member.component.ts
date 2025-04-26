import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';
import { RouterLink } from '@angular/router';
import { Member } from '../../models/member.model';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-member',
  imports: [
    RouterLink,
    MatCardModule,
    MatIconModule
  ],
  templateUrl: './member.component.html',
  styleUrl: './member.component.scss'
})
export class MemberComponent {
  accessorService = inject(AccountService);
  membrs: Member[] | undefined;

  ngOnInit(): void {
    this.getAll();
  }

  getAll(): void {
    this.accessorService.getAllMember().subscribe({
      next: (res) => {
        this.membrs = res
      }
    })
  }
}
