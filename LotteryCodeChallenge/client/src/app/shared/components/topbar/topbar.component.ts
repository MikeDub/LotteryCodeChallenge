import { NavigationService } from './../../services/navigation.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html'
})
export class TopbarComponent  {

  constructor(private nagivator: NavigationService) {

  }

  Navigate(link: string) {
    this.nagivator.NavigateTo(link);
  }

}
