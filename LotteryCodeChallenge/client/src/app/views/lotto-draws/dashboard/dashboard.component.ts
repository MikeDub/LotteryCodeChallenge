import { SnackNotificationService } from './../../../shared/services/notifications/notification.service';
import { Component, AfterContentInit } from '@angular/core';
import { sharedAnimations } from 'src/app/shared/animations/shared-animations';
import { NavigationService } from 'src/app/shared/services/navigation.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  animations: sharedAnimations
})
export class DashboardComponent implements AfterContentInit {

  constructor(protected notifier: SnackNotificationService, private nagivator: NavigationService) {
    console.log('dashboard');
   }

  ngAfterContentInit() {
    
  }

  Navigate(link: string){
    this.nagivator.NavigateTo(link);
  }

}
