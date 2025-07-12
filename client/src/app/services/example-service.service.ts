import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ExampleServiceService {
  ageSige=signal<number>(0);

  updateAgeSig():void{
    this.ageSige.set(10);
  }
}
