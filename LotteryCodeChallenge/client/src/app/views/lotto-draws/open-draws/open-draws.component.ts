import { NavigationService } from 'src/app/shared/services/navigation.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-open-draws',
  templateUrl: './open-draws.component.html',
  styleUrls: ['./open-draws.component.scss']
})
export class OpenDrawsComponent implements OnInit {

  constructor (private navigator: NavigationService) {
    console.log('open draws');

  }

  ngOnInit() {
 
  }

  Navigate(link: string){
    this.navigator.NavigateTo(link);
  }

}
