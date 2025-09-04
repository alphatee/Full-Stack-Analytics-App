import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of, tap } from 'rxjs';
import { AppUser } from 'src/app/security/app-user';
import { AppUserAuth } from 'src/app/security/app-user-auth';
import { MessageService } from '../messaging/message.service';
import { environment } from 'src/environments/environment';

const API_ENDPOINT = "security/"; // because we are going to call the SecurityController
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  securityObject: AppUserAuth = new AppUserAuth();
  apiUrl: string = "";

  constructor(private http: HttpClient,
    private msgService: MessageService) {
    this.apiUrl = environment.apiUrl + API_ENDPOINT; // as set to 5000 from another project, now set to 4200 for my project
  }

  login(entity: AppUser): Observable<AppUserAuth> {
    // Delete userId property for posting
    delete entity.userId;

    return this.http.post<AppUserAuth>(this.apiUrl + "login",
      entity, httpOptions).pipe(
        tap(resp => {
          // Use object assign to update the current object
          // NOTE: Don't create a new AppUserAuth object
          //       because that destroys all references to object
          Object.assign(this.securityObject, resp);
        }),
        catchError(
          this.handleError<AppUserAuth>('login',
            'Invalid user name/password', new AppUserAuth()))
      );
  }

  logout(): void {
    this.securityObject.init(); // Wipes out all the permissions and authentication of user, effectively "logging out".
  }

  private handleError<T>(operation = 'operation', msg = '', result?: T) {
    // Add error messages to message service
    return (error: any): Observable<T> => {
      // Clear any old messages
      this.msgService.clearExceptionMessages();
      this.msgService.clearValidationMessages();

      msg = "Status Code: " + error.Status + " - " + msg || "";

      console.log(msg + " " + JSON.stringify(error));

      // Set the last exception generated
      this.msgService.lastException = error;

      switch (error.Status) {
        case 400: // Model State Error
          if (error.error) {
            // Add all error messages to the validationMessages list
            Object.keys(error.error.errors)
              .map(keyName => this.msgService
                .addValidationMessage(error.error.errors[keyName][0]));
            // Reverse the array so error messages come out in the right order
          }
          break;
        case 401: // Unauthorized
          this.msgService.addExceptionMessage(
            "Error 401: Not authorized for that function.");
          break;
        case 404:
          this.msgService.addExceptionMessage(msg);
          break;
        case 500:
          this.msgService.addExceptionMessage(error.error);
          break;
        case 0:
          this.msgService.addExceptionMessage(
            "Unknown error, check to make sure the Web API URL can be reached." + " - ERROR");
          break;
        default:
          this.msgService.addExceptionMessage(error);
          break;
      }

      //Return default configuration values
      return of(result as T)
    };
  }
}
