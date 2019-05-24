import { SnackNotificationService } from './notifications/notification.service';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {

  constructor(private router: Router, private notifier: SnackNotificationService) { }

  NavigateTo(link: string){
    if (link != null) {
      console.log('Navigated to ' + link);
      this.router.navigate([link]).then(
        (success) => {
          if (success == null) {
              this.notifier.notifyError('Cannot navigate to ' + link, new Error('Bad link'));
          }
        },
        (failure) => {
          this.notifier.notifyError('Cannot navigate to ' + link, new Error(failure));
        }
      );
    }
  }
}
