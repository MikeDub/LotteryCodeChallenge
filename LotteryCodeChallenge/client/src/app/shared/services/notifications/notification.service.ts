import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material';
import { INotificationService } from './INotificationService';

@Injectable({
  providedIn: 'root'
})
// Material Snack Bar Implementation of the notification service
export class SnackNotificationService implements INotificationService {

  private config: MatSnackBarConfig;

  constructor(private snackBar: MatSnackBar) {
    this.config = new MatSnackBarConfig();
  }

  notify(text: string) {
    this.config.duration = 5;
    this.snackBar.open(text);
  }

  notifyError(text: string, errorInfo: Error) {
    this.snackBar.open(text);
    throw errorInfo;
  }

  // For this simple app implementation, we will just say that success is a quick notification.
  notifySuccess(text: string) {
    this.config.duration = 3;
    this.snackBar.open(text, null, this.config);
  }

}
