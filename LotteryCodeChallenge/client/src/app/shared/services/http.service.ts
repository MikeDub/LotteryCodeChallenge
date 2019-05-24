import { SnackNotificationService } from './notifications/notification.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpEvent } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { DrawRequest } from '../models/DrawRequest';

@Injectable({
  providedIn: 'root'
})
export class HttpService<T> {

  protected serviceUrl: string;
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      Accept: 'application/json'
    })
  };

  constructor(private http: HttpClient, protected notifier: SnackNotificationService) {
      // Change the port number to reflect what the API is running on
      const portNumber = 44318;
      // If environment is set to production, then talk to the server, else talk to the local instance.
      if (environment.production) {
        this.serviceUrl = 'Insert production url here (yet to be supported)';
      } else {
        this.serviceUrl = 'https://localhost:' + portNumber + '/api/draws';
      }
   }

  public SendGet(methodName: string): Observable<T> {
    return this.http.get<T>(this.serviceUrl + methodName);
  }

  public SendPost(methodName: string, request: DrawRequest): Observable<any> {
    // if (statusMessage != "") this.toastr.info(statusMessage);
    const route = this.serviceUrl + methodName;
    try {
      let response = this.http.post(route, request, this.httpOptions);
      return response.pipe();
    } catch (error) {
      this.HandleError(error);
      throw error;
    }
  }

  protected HandleError(error: Error) {
    // console.log('errors encountered with post/get..');
    const text = error.message;
    if (text.length === 0) {
      this.notifier.notifyError('Possible server error: remote data operation failed', error);
    } else {
      this.notifier.notifyError(text, error);
    }
    return text;
  }


}
