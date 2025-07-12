import { Component, inject } from '@angular/core';
import { ExampleServiceService } from '../../services/example-service.service';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
exampelService = inject(ExampleServiceService);
}
