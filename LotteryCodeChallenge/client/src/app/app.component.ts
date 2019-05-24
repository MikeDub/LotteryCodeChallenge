import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Lucky Lotteries Draws Challenge!';
  isModuleLoading: boolean;
  /**
   *
   */
  constructor() {
    console.log('Started App');

  }
}
