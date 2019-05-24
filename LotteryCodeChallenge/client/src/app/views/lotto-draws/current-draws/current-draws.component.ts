import { DrawTable } from './../../../shared/models/ITable';
import { Component, OnInit, AfterViewInit, EventEmitter } from '@angular/core';
import { NavigationService } from 'src/app/shared/services/navigation.service';

@Component({
  selector: 'app-current-draws',
  templateUrl: './current-draws.component.html',
  styleUrls: ['./current-draws.component.scss']
})
export class CurrentDrawsComponent implements OnInit {

  currentDrawsSubscription: EventEmitter<DrawTable>;

  constructor(private nagivator: NavigationService) {

   }

  ngOnInit() {
    // this.currentDrawsSubscription = this.tableService.getData

  }

  Navigate(link: string){
    this.nagivator.NavigateTo(link);
  }

}
