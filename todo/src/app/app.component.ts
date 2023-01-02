import { Component } from '@angular/core';
import { Todo } from 'src/Models/todo.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public todos: Todo[] = []; //Tipar usando :
  public title: String = 'Minhas tarefas';

  constructor() {
    this.todos.push(new Todo('Passear com o cachorro', false, 1));
    this.todos.push(new Todo('Ir ao mercado', false, 2));
    this.todos.push(new Todo('Cortar cabelo', false, 3));
  }
}
