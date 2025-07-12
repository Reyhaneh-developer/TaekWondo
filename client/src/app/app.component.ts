import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AccountService } from './services/account.service';
import { FooterComponent } from "./componets/footer/footer.component";
import { NavbarComponent } from "./componets/navbar/navbar.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FooterComponent, NavbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  accountService=inject(AccountService);

  ngOnInit(): void {
    let loggedInUser:string|null=localStorage.getItem("loggedInUser");
    console.log(loggedInUser);

    if(loggedInUser!=null)
      this.accountService.setCurrentUser(JSON.parse(loggedInUser))
  }
}
