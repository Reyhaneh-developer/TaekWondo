import { Routes } from '@angular/router';
import { HomeComponent } from './componets/home/home.component';
import { RegisterComponent } from './componets/accunt/register/register.component';
import { LoginComponent } from './componets/accunt/login/login.component';
import { FooterComponent } from './componets/footer/footer.component';
import { NavbarComponent } from './componets/navbar/navbar.component';
import { MemberComponent } from './componets/member/member.component';
import { NotFoundComponent } from './componets/not-found/not-found.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'account/register', component: RegisterComponent },
    { path: 'account/login', component: LoginComponent },
    { path: 'footer', component: FooterComponent },
    { path: 'navbar', component: NavbarComponent },
    { path: 'members', component: MemberComponent },
    { path: '**', component: NotFoundComponent }
];
