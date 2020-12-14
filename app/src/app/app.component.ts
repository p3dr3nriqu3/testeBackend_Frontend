import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public apps: any[] = [];
  public title: String = 'Minhas Tarefas';

   constructor() {
    this.apps.push(' ')
    
  }
}