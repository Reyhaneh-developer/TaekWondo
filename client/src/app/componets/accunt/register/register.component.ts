import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AccountService } from '../../../services/account.service';
import { FormBuilder, FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AppUser } from '../../../models/app-user.moder';

@Component({
  selector: 'app-register',
  imports: [
    RouterLink,
MatButtonModule,MatInputModule,
MatFormFieldModule,
MatFormFieldModule,
FormsModule,ReactiveFormsModule
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  accountService = inject(AccountService);
  fB = inject(FormBuilder);

  registerFg = this.fB.group({
    emailCtrl: ['', [Validators.required, Validators.email]],
    nameCtrl: '',
    lastNameCtrl: '',
    nationalIdCtrl: '',
    passwordCtrl: '',
    confirmPasswordCtrl: '',
    genderCtrl: '',
    countryCtrl: '',
    cityCtrl: '',
    skillLevelCtrl: '',
    ageCtrl: 0,
    datOfBirthCtrl: ''
  });

  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }

  get NameCtrl(): FormControl {
    return this.registerFg.get('nameCtrl') as FormControl;
  }

  get LastNameCtrl(): FormControl {
    return this.registerFg.get('lastNameCtrl') as FormControl;
  }

  get NationalIdCtrl(): FormControl {
    return this.registerFg.get('nationalIdCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }

  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }

  get GenderCtrl(): FormControl {
    return this.registerFg.get('genderCtrl') as FormControl;
  }

  get CountryCtrl(): FormControl {
    return this.registerFg.get('countryCtrl') as FormControl;
  }

  get CityCtrl(): FormControl {
    return this.registerFg.get('cityCtrl') as FormControl;
  }

  get SkillLevelCtrl(): FormControl {
    return this.registerFg.get('skillLevelCtrl') as FormControl;
  }

  get AgeCtrl(): FormControl {
    return this.registerFg.get('ageCtrl') as FormControl;
  }

  get DatOfBirthCtrl(): FormControl {
    return this.registerFg.get('datOfBirthCtrl') as FormControl;
  }

  register(): void {
    let user: AppUser = {
      email: this.EmailCtrl.value,
      name: this.NameCtrl.value,
      lastName: this.LastNameCtrl.value,
      nationalId: this.NationalIdCtrl.value,
      password: this.PasswordCtrl.value,
      confirmPassword: this.PasswordCtrl.value,
      gender: this.GenderCtrl.value,
      country: this.CountryCtrl.value,
      city: this.CityCtrl.value,
      skillLevel: this.SkillLevelCtrl.value,
      age: this.AgeCtrl.value,
      datOfBirth: this.DatOfBirthCtrl.value
    }

    this.accountService.register(user).subscribe({
      next: (res) => console.log(res),
      error: (err) => console.log(err.error)
    });
  }
}
