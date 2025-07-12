import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AccountService } from '../../services/account.service';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatListModule } from '@angular/material/list';
import { ExampleServiceService } from '../../services/example-service.service';
@Component({
  selector: 'app-navbar',
  imports: [
    MatButtonModule,
    MatIconModule,
    MatToolbarModule, RouterLink, MatMenuModule, MatDividerModule,
    MatListModule, CommonModule
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  accountService = inject(AccountService);
  exampleService = inject(ExampleServiceService);

  logout(): void {
    this.accountService.logout();
  }
}
